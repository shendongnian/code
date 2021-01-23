    Form 2 Code
    -------------------
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Math_Quiz
    {
        public partial class debugForm : Form
        {
            public debugForm(int value1, string value2)
            {
                InitializeComponent();
                //set the values to local variables.
            }
    
            private void timeButton_Click(object sender, EventArgs e)
            {
    
            }
        }
    }
    private void makeMenu(object sender, EventArgs e)
    {
        debugForm form = new debugForm(intvalue, stringvalue);
        form.Show();
    }
