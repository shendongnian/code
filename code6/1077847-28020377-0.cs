    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace deleteMe
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private int correctCount = 0; // field
    
            private int incorrectCount = 0; // field
    
            private void G_Click(object sender, EventArgs e)
            {
                if (go.Visible == true)
                {
                    go.Visible = false;
                    Random rnd = new Random();
                    int y = rnd.Next(1, 7); // local variable
    
                    if (y == 1)
                    {
                        eo.Visible = true;
                    }
                    if (y == 2)
                    {
                        ao.Visible = true;
                    }
                    if (y == 4)
                    {
                        dd.Visible = true;
                    }
                    if (y == 5)
                    {
                        go.Visible = true;
                    }
                    if (y == 6)
                    {
                        eeo.Visible = true;
                    }
    
                    timer1.Start();
    
                    incorrect.Text = "Correct";
                }
                else
                {
                    incorrect.Text = "Incorrect";
                }
    
    
                if (label1.Text = "Correct")
                {
                    correctCount++;
                    correct.Text = correctCount.ToString();
                }
                else
                {
                    incorrectCount++;
                    incorrect.Text = incorrectCount.ToString();
                }
            }
        }
    }
