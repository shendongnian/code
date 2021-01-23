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
                mymainform.textupdatert(textBox1.Text); // Update Parent form
                this.Close(); // Exit 
            }
    
        }
    }
