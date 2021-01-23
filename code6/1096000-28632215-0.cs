    private void button1_Click(object sender, EventArgs e)
    {
        string username = "Admin";
        string password = "root";
        var message = string.Empty;
        bool loginEmpty = string.IsNullOrEmpty(textBox1.Text),
             passEmpty = string.IsNullOrEmpty(textBox2.Text),
             loggedIn = (textBox1.Text == username) && (textBox2.Text == password);
        if (!loggedIn) 
        {
            if (loginEmpty && passEmpty)
                message = " - Fields are not filled";
            else if (passEmpty)
                message = " - No Password inserted";
            else if (loginEmpty)
                message = " - No username inserted";
            MessageBox.Show("Login failed" + message);
            return;
        }
            
        MessageBox.Show("Login succeded");
    }
