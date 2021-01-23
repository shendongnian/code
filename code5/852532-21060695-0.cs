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
            public int x = 550, y = 10;
            public Form1()
            {
                InitializeComponent();
    
                var panel1 = new Panel()
                {
                    Size = new Size(600, 600),
                    Location = new Point(20, 130),
                    BorderStyle = BorderStyle.FixedSingle,
                    Name = "tktPanel",
                };
                for (int i = 0; i < 20; i++)
                {
                    CheckBox chkpremiumtickets = new CheckBox();
                    chkpremiumtickets.Text = " ";
                    chkpremiumtickets.Name = "chk-" + i.ToString();
                    chkpremiumtickets.Location = new Point(x, y);
                    panel1.Controls.Add(chkpremiumtickets);
                    chkpremiumtickets.Visible = true;
                    x = x - 55;
                    if (x < 55)
                    {
                        y = y + 20;
                        x = 550;
                    }
                }
    
                x = 550;
                y = 10;
    
                Controls.Add(panel1);
                panel1.Visible = true;
    
            }
    
            private IEnumerable<string> GetSelectedBtn()
            {
                //get selected chk_box
                var panel = (Panel)this.Controls["tktPanel"];
    
                foreach (var control in panel.Controls)
                {
                    var chk = control as CheckBox;
                    if (chk != null && chk.Checked)
                    {
                        yield return chk.Name;
                    }
                }
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (var chkName in GetSelectedBtn())
                {
                    MessageBox.Show(chkName);
                }
            }
        }
    }
