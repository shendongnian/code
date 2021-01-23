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
            //simulating processing of login authentication below, use actual login auth instead 
            Thread.Sleep(5000);
            bLoginSuccessful = true;
            if (bLoginSuccessful == true)
                parent.LoginSuccessful();
        }
    }
