    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2();
                //check if button1 clicked and then change the background
                if(frm2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                      this.BackgroundImage = frm2.GetBackImage();
                }
            }
        }
    }
