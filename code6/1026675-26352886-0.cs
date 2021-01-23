    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace PrimeCheck
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text; 
            double testthis = 0;
            if (double.TryParse(textBox1.Text, out testthis))
            {
                if (CheckForPrime(testthis))
                {
                    MessageBox.Show("prime time!!");
                }
            }
        }
        bool CheckForPrime(double number)
        {//there are better ways but this is cheap and easy for an example
            bool result = true;//assume we are prime until we can prove otherwise
            for (double d = 2; d < number; d++)
            {
                if (number % d == 0) 
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
    }
