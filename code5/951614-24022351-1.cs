    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {       
            public Form1()
            {
                InitializeComponent();
            }
            public void present_Click(object sender, EventArgs e)
            {
                if (room1.Checked)
                {
                    System.Diagnostics.Process.Start(@"room1.txt");
                }
                else if (room2.Checked)
                {
                    System.Diagnostics.Process.Start(@"room2.txt");
                }
                else (room3.Checked)
                {
                    System.Diagnostics.Process.Start(@"room3.txt");
                }
            }
        }
    }
