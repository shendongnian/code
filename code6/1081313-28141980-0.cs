    using System;
    using System.Windows.Forms;
    
    namespace StringBuilder
    {
        public partial class frmMain : Form
        {
            public frmMain()
            {
                InitializeComponent();
            }
    
            private void btnInput_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                if (button != null)
                {
                    if (button.Text == "Space")
                        lblOutput.Text += " ";
                    else
                        lblOutput.Text += button.Text;
                }
            }
        }
    }
