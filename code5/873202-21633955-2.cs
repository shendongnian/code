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
            TextBox[] txtBox;
            Label[] lbl;
    
            int n = 4;
            int space = 20;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                txtBox = new TextBox[n];
                lbl = new Label[n];
    
                for (int i = 0; i < n; i++)
                {
                    txtBox[i] = new TextBox();
                    txtBox[i].Name = "n" + i;
                    txtBox[i].Text = "n" + i;
    
                    lbl[i] = new Label();
                    lbl[i].Name = "n" + i;
                    lbl[i].Text = "n" + i;
                }
    
    
                for (int i = 0; i < n; i++)
                {
                    txtBox[i].Visible = true;
                    lbl[i].Visible = true;
                    txtBox[i].Location = new Point(40, 50 + space);
                    lbl[i].Location = new Point(10, 50 + space);
                    this.Controls.Add(txtBox[i]);
                    this.Controls.Add(lbl[i]);
                    space += 50;
                }
    
            }
        }
    }
