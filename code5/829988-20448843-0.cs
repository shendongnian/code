    protected void Button1_Click(object sender, EventArgs e)
    {
        users.Add(new User { connectionid = TextBox1.Text, nick = TextBox2.Text });
        foreach (User u in users) {
            lbUsers.Items.Add(new ListItem(u.nick, u.connectionid));
        }
    }
