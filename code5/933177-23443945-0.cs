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
            static Form2 f1=new Form2();
    
            private void Form1_Load(object sender, EventArgs e)
            {
                f1.Show();
                f1.FormClosing += new FormClosingEventHandler(f1_FormClosing);
            }
    
            void f1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true; //I'm sorry Dave, I'm afraid I can't do that.
                }
            }
        }
    }
