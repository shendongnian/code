    {
        // Loads your users storage
        var users = File.ReadAllLines(@"C:\Other\myFile.txt");
        // Creates the line with username + password
        var usernamePassword = String.Format("Username: {0} Password: {1}", userNameBox.Text, passwordBox.Text);
        // Locates the user on your storage
        var userFound = users.SingleOrDefault(_u => _u.Equals(usernamePassword));
        if (userFound != null)
        {
            MessageBox.Show("Welcome back, " + userNameBox.Text);
        }
        else
        {
            MessageBox.Show("Sorry, you have entered incorrect details\n\nPlease try again");
            userNameBox.Text = "";
            passwordBox.Text = "";
        }
    }
