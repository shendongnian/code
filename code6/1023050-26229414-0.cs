    private void Login()
    {
        if (this.IdTextBox.Text == "ID" && this.PasswordTextBox.Text == "Password")
        {
            Main form = new Main();
            this.Hide();
            form.ShowDialog();
        }
        else
        {
            MessageBox.Show("Please enter correct credentials and try again!");
        }
    }
    
    private void loginBtn_Click(object sender, EventArgs e)
    {
        Login();
    }
