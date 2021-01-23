    private void login_Click(object sender, EventArgs e)
    {
        string email = lemail.Text;
        Dictionary<string, string> dik = sqlClient.Select("UserList", "YOUR_EMAIL_FIELD = " + email);
        var lines = dik.Select(kv => kv.Key + ": " + kv.Value.ToString());
        logged.AppendText(string.Join(Environment.NewLine, lines));
    }
