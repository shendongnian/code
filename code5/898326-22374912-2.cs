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
            public static Exception formException;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                try
                {
                    int.Parse("This will raise and excpetion because i can't convert this to an int... ");
                }
                catch (Exception ex)
                {
                    formException = ex;
                    Form2 frm = new Form2();
                    this.Hide();
                }
            }
        }
    }
