       internal class UserData
        {
            public byte[] Password { get; set; }
            public byte[] Salt { get; set; }
        }
        public string Connection { get; set; }
        private void UpdateData(string mail, string password)
        {
            // not a clue what to do here....
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var password = textBox1.Text;
            var u = HashPassword(password);
            var b = new SqlConnectionStringBuilder {DataSource = "127.0.0.1", IntegratedSecurity = true};
            Connection = b.ConnectionString;
            InsertData("test@domain.com", password);
            label1.Text = string.Format("Using direct check: {0}\nVia the database: {1}", 
                CheckPassword(password, u.Password, u.Salt),
                ValidateLogIn("test@domain.com", password));
        }
