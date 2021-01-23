    public partial class Form1 : Form
    {
        String pass = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string value = e.KeyChar.ToString();
            pass += value;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
               //Now check the password with your config file.
               //You may have to reset the variable if the pass does not match with the config.
            }
        }
    }
