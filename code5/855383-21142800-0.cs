    private void login_Click(object sender, EventArgs e)
    {
        if (ok(username.Text, password.Text) > 0)
        {
            MessageBox.Show("Access granted");
            Form6 f6 = new Form6(); // create your next form instance,(form6, for example)
            f6.Open();
            this.Close();
       }
       ....
    }
