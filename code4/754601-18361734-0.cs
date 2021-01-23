    private void btnSubmit_Click(object sender, EventArgs e)
    {
        string username = txtUser.Text;
        Settings.Default.Username = username;
        Settings.Default.Save();
    }
