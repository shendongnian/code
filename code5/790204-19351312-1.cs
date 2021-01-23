    public partial class Form2 : Form
    
        {
            public Form2()
            {
                InitializeComponent();
            }
        
            private void buttonLogin_Click(object sender, EventArgs e)
            {
                // if username and password is ok set the dialog result to ok
                this.DialogResult = DialogResult.OK;
        
                this.Close();
            }
        }
