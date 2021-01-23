    public partial class LoginForm : Form
    {
        FormMain parent;
        bool bLoginSuccessful = false;
        public LoginForm(FormMain parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bLoginSuccessful = true;
            Thread.Sleep(5000);
            if (bLoginSuccessful == true)
                parent.LoginSuccessful();
        }
    }
