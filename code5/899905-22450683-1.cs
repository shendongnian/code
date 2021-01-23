    switch (GetUserType(username, password).Equals(true))
    {
        case "Administrator":
            Enrollment enroll = new Enrollment();
            MessageBox.Show("Successfully Log In", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            enroll.Show();
            this.Hide();
            break;
        case "Staff":
            Enrollment enroll = new Enrollment();
            MessageBox.Show("Successfully Log In", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            enroll.Show();
            this.Hide();
            break;
        case "Student":
            Subject sub = new Subject();
            MessageBox.Show("Successfully Log In", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            sub.Show();
            this.Hide();
            break;
        default:
            MessageBox.Show("Invalid Username or Password", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
            break;
    }
