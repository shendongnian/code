    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
        namespace Sampless
        {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            int n = 4;
    
            private void btnDisplay_Click(object sender, EventArgs e)
            {
                TextBox[] textBox = new TextBox[n];
                Label[] label = new Label[n];
                int labelX, labelY, textboxX, textboxY;
    
                labelX = 20;
                labelY = 20;
                textboxX = 50;
                textboxY = 20;
    
                for (int i = 0; i < n; i++)
                {
                    textBox[i] = new TextBox();
                    textBox[i].Name = "n" + i;
                    textBox[i].Text = "n" + i;
                    textBox[i].Location = new Point(textboxX, textboxY);
    
                    label[i] = new Label();
                    label[i].Name = "n" + i;
                    label[i].Text = "n" + i;
                    label[i].Location = new Point(labelX, labelY);
    
                    labelY += 25;
                    textboxY += 25;
                }
    
                for (int i = 0; i < n; i++)
                {
                    this.Controls.Add(textBox[i]);
                    this.Controls.Add(label[i]);
                }
            }
         }
    }
