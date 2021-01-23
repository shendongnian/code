    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class About : Form
        {
           private Mainform mymainform; // Holds main form instance
           // Contructor is updated to take the instance of Main Form
           public About(Mainform mainform)
           {
             InitializeComponent();
             mymainform = mainform;
           }
    
            private void button1_Click(object sender, EventArgs e)
            {
                mymainform.textupdatert(textBox1.Text); // Update Parent form's'textBox1
                this.Close(); // Close about form and Exit 
            }
    
        }
    }
