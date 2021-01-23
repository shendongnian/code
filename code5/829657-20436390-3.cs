    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Dlicari_loops
    {
        public partial class Form5 : Form
        {
            int value;
            int maxvalue;
            public Form5()
            {
                InitializeComponent();
                button1.Click += new EventHandler(button1_Click); //register click event handler here
            }
    
            private void Form5_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                value = int.Parse(textBox2.Text);
                maxvalue = int.Parse(textBox1.Text);
                listBox1.Items.Clear();
                while (value < maxvalue)
                {
                    try
                    {
                        checked
                        {
                            listBox1.Items.Add(value);
                            value = value * value;
                        }
                    }
                    catch
                    {
                        listBox1.Items.Add("You have reached the maximum the computer can do.");
                        break;
                    }
                }
                listBox1.Items.Add("You have reached the maximum you had set.");
            }
    
    
        }
    }
