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
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //Form1 frm1 = new Form1();
                //frm1.BackgroundImage = button1.BackgroundImage;
    	        this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
    
    	   public Image GetBackImage()
           {
               return this.button1.BackgroundImage;
           }
        }
    }
