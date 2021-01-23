    string userType = GetUserType(username, password);
    if (userType.Equals("Administrator", StringComparison.InvariantCultureIgnoreCase))
    {
        Enrollment enroll = new Enrollment();
        MessageBox.Show("Successfully Log In", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        enroll.Show();
        this.Hide();
    }
    else if (userType.Equals("Staff", StringComparison.InvariantCultureIgnoreCase))
    {
        Enrollment enroll = new Enrollment();
        MessageBox.Show("Successfully Log In", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        enroll.Show();
        this.Hide();
    }
    else if (userType.Equals("Student", StringComparison.InvariantCultureIgnoreCase))
    {
        Subject sub = new Subject();
        MessageBox.Show("Successfully Log In", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        sub.Show();
        this.Hide();
    } else
    {
        MessageBox.Show("Invalid Username or Password", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtUsername.Clear();
        txtPassword.Clear();
        txtUsername.Focus();
    }
