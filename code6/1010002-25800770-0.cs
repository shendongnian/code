    Class MainForm
    {
        LoginForm login_form;
        public MainForm()
        {
            
        }
        public MainForm(LoginForm log)
        {
            login_form = log;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {                 
                       
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {                 
            this.Hide();
            ShowMessage("Successfully connected.");
            if(login_form == NULL)
            {              
                login_form = new LoginForm(this);
            }
            login_form.Show();                
        }
    }
   
    Class LoginForm
    {
        MainForm main_form;
        public LoginForm()
        {
            
        }
        public LoginForm(MainForm man)
        {
            main_form = man;
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {                 
                       
        }
        private void buttonDisConnect_Click(object sender, EventArgs e)
        {                 
            this.Hide();
            ShowMessage("Successfully Disconnected.");               
            
            if(main_form == NULL)
            {              
                main_form = new MainForm(this);
            }
            main_form.Show();;                
        }
    }
