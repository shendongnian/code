    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            string input = string.Empty;
            string operand1 = string.Empty;
            string operand2 = string.Empty;
            char operation;
            double result = 0.0;
    
            public Form1()
            {
                InitializeComponent();
    
                this.KeyPress +=
                    new KeyPressEventHandler(Form1_KeyPress);
            }
    
            void Form1_KeyPress(object sender, KeyPressEventArgs e)
            {
                //keypressed
                System.Console.WriteLine(e.KeyChar);
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "1";
                this.textBox1.Text += input;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "2";
                this.textBox1.Text += input;
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "3";
                this.textBox1.Text += input;
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "4";
                this.textBox1.Text += input;
            }
    
            private void button5_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "5";
                this.textBox1.Text += input;
            }
    
            private void button6_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "6";
                this.textBox1.Text += input;
            }
    
            private void button7_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "7";
                this.textBox1.Text += input;
            }
    
            private void button8_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "8";
                this.textBox1.Text += input;
            }
    
            private void button9_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "9";
                this.textBox1.Text += input;
            }
    
            private void button10_Click(object sender, EventArgs e)
            {
                operand2 = input;
                double num1, num2;
                double.TryParse(operand1, out num1);
                double.TryParse(operand2, out num2);
    
                this.textBox1.Text = "";
                this.input = string.Empty;
                this.operand1 = string.Empty;
                this.operand2 = string.Empty;
    
                if (operation == '+')
                {
                    result = num1 + num2;
                    textBox1.Text = result.ToString();
                }
                else if (operation == '-')
                {
                    result = num1 - num2;
                    textBox1.Text = result.ToString();
                }
                else if (operation == '*')
                {
                    result = num1 * num2;
                    textBox1.Text = result.ToString();
                }
                else if (operation == '/')
                {
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        textBox1.Text = "undefined";
                    }
    
                }
            }
    
            private void button11_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                this.input = string.Empty;
                this.operand1 = string.Empty;
                this.operand2 = string.Empty;
            }
    
            private void button12_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                input += "0";
                this.textBox1.Text += input;
            }
    
            private void button13_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                operand1 = input;
                operation = '*';
                input = string.Empty;
                this.textBox1.Text += input;
            }
    
            private void button14_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                operand1 = input;
                operation = '+';
                input = string.Empty;
                this.textBox1.Text += input;
    
            }
    
            private void button15_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                operand1 = input;
                operation = '-';
                input = string.Empty;
                this.textBox1.Text += input;
            }
    
            private void button16_Click(object sender, EventArgs e)
            {
                this.textBox1.Text = "";
                operand1 = input;
                operation = '/';
                input = string.Empty;
                this.textBox1.Text += input;
            }
        }
    }
