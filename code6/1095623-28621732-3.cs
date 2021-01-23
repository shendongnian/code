    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class About : Form
        {
            Mainform mymainform;
    
            public About(Mainform mainform)
            {
                InitializeComponent();
                mymainform = mainform;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                mymainform.textupdatert(textBox1.Text); // Update Parent form.'textBox1' is txtbob in about but not the same as in Main form
                this.Close(); // Close about form and Exit 
            }
    
        }
    }
