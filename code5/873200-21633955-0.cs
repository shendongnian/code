    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            TextBox txtBox;
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                txtBox = new TextBox();
                txtBox.Location = new Point(10, 50);
                txtBox.Visible = true;
                Controls.Add(txtBox);
            }
        }
    }
