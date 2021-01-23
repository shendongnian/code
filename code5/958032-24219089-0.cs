    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Office.Tools.Ribbon;
    using System.Windows.Forms;
    
    namespace EmailHelper
    {
        public partial class EmailHelperRibbon
        {
            private void EmailHelperRibbon_Load(object sender, RibbonUIEventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, RibbonControlEventArgs e)
            {
                System.Windows.Forms.MessageBox.Show("Your Ribbon Works!");
                Form Form1 = new Form1();
                Form1.Show();
            }
        }
    }
