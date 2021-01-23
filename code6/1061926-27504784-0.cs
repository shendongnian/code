        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var success = txtSuccess.Text;
            var userId = txtUserId.Text;
            var frm2 = new Form2();
            frm2.AddGridViewRows(firstName, lastName, success, userId);
        }
