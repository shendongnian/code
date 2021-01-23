        private void button1_Click(object sender, EventArgs e)
        {
            frm.Test(this);
        }
        private Form1 MF;
        
        public User_Form(Form _Form, Client.State client)
        {
            this.frm = _Form;
            InitializeComponent();
        }
