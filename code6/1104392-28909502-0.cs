    private void acceptBtn_Click(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(usersPath);
        string usersTXT = sr.ReadLine();
        if (user_txt.Text.Contains(usersTXT))
        {
            loginPanel.Visible = false;
        }
    }
