    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Mainform : Form
        {
            public Mainform()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                new About(this).ShowDialog(); // pass main form to about form and show it a showdialog
            }
    
            // Public textbox updating method 
            public void textupdatert(string input)
            {
                textBox1.Text = input; // textBox1 is the textbox we need to update in Main form
            }
        }
    }
