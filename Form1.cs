using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = "";
        Boolean op_pressed = false;
        public Form1()
        {
            InitializeComponent();
        }
        private Double Evaluate(String expression)
        {
            expression = expression.Replace(",", ".");
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", String.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);
                return Double.Parse((String)row["expression"]);
            }
            catch
            {
                return Double.Parse("0");
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((result.Text == "0") || (op_pressed))
            {
                result.Clear();
                op_pressed = false;
            }
            result.Text += b.Text;
        } //NUM_Button
        private void operator_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(result.Text);
            result.Text = Evaluate(equation.Text + result.Text).ToString();
            equation.Text += value + " " + operation + " ";
            op_pressed = true;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            lblContent.Text = "Histórico: ";
            equation.Text = "";
            result.Enabled = true;
            result.Text = "0";
        } //C
        private void button17_Click(object sender, EventArgs e) //CE
        {
            result.Text = "0";
        }
        private void button16_Click(object sender, EventArgs e) //IGUAL
        {
            String conta = equation.Text + result.Text;
            Double resultado = Evaluate(conta);
            lblContent.Text = "Resultado";
            result.Enabled = false;
            result.Text = resultado.ToString();
            equation.Text = "";
        }
        private void button19_Click(object sender, EventArgs e)
        {
            result.Text = result.Text.Substring(0, result.Text.Length - 1);
        } //DEL
        private void button23_Click(object sender, EventArgs e) //X elevado ao Quad
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.Pow(Double.Parse(result.Text), 2).ToString();
            op_pressed = true;
        }
        private void button25_Click(object sender, EventArgs e) //X elevado ao Cubo
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.Pow(Double.Parse(result.Text), 3).ToString();
            op_pressed = true;
        }
        private void button20_Click(object sender, EventArgs e) //SEN
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.Sin(Double.Parse(result.Text)).ToString();
            op_pressed = true;
        }
        private void button21_Click(object sender, EventArgs e) //COS
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.Cos(Double.Parse(result.Text)).ToString();
            op_pressed = true;
        }
        private void button22_Click(object sender, EventArgs e) //TAN
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.Tan(Double.Parse(result.Text)).ToString();
            op_pressed = true;
        }
        private void button26_Click(object sender, EventArgs e) //FATORIAL
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            Double num = Double.Parse(result.Text);
            Double fatorial = num;
            for(double i = num - 1; i >= 1; i--)
            {
                fatorial *= i;
            }
            result.Text = fatorial.ToString();
            op_pressed = true;
        }
        private void button24_Click(object sender, EventArgs e) //RAIZ QUADRADA
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.Sqrt(Double.Parse(result.Text)).ToString();
            op_pressed = true;
        }
        private void button27_Click(object sender, EventArgs e) //π(PI) 
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.PI.ToString();
            op_pressed = true;
        }
        private void button28_Click(object sender, EventArgs e)//Logaritimo
        {
            result.Enabled = false;
            lblContent.Text = "Resultado";
            result.Text = Math.Log(Double.Parse(result.Text)).ToString();
            op_pressed = true;
        }
    }
}
