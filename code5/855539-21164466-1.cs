    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace NavAutomation
    {
        public partial class NAVForm : Form
        {
            
            public NAVForm()
    
            {
                
                InitializeComponent();
            }
    
            private void NAVForm_Load(object sender, EventArgs e)
            {
                
            }
    
            public string RetVal1 { get; set; }
            
            private void button2_Click(object sender, EventArgs e)
            {
                if (textBox1.Text.Trim().Length != 0)
                {
                    this.RetVal1 = textBox1.Text;
                }
                else
                {
                    this.RetVal1 = "didn't work";
                }
                this.Close();
            }
        }
    }
