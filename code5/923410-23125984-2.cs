    using System;
    using System.Windows.Forms;
    
    namespace WFsimulateMouseClick
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                button1_Click(button1, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 1, 1, 1));
    
                //by the way
                //button1.PerformClick();
                // and
                //button1_Click(button1, new EventArgs());
                // are the same
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("clicked");
            }
        }
    }
