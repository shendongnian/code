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
            Form2 f2 = new Form2();
            public Form1()
            {
                InitializeComponent();
            }
            private void btnShowForm2_Click(object sender, EventArgs e)
            {
                f2.Show();
            }
        }
    }
