    using System;
      using System.Collections.Generic;
      using System.ComponentModel;
      using System.Data;
      using System.Drawing;
      using System.Linq;
      using System.Text;
      using System.Windows.Forms;
      namespace WindowsFormsApplication1
       {
          public partial class Form1 : Form
          {
              public Form1()
              {
                  InitializeComponent();
              }
              private void button1_Click(object sender, EventArgs e)
              {
                  double num1;
                  double num2;
                  double answer;
                  num1 = double.Parse(textBox1.Text);
                  num2 = double.Parse(textBox2.Text);
                  if (listBox1.SelectedIndex == 0)
                  {
                  answer = num1 + num2
                  }
                  if (listBox1.SelectedIndex == 1)
                  {
                  answer = num1 - num2
                  }
                  if (listBox1.SelectedIndex == 2)
                  {
                  answer = num1 * num2
                  }
                  if (listBox1.SelectedIndex == 3)
                  {
                  answer = num1 / num2
                  }
                  textBox4.Text = Convert.ToString(answer);
              }
          }
      }
