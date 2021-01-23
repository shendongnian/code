    {
        // Loads your users storage
        var users = File.ReadAllLines(@"C:\Other\myFile.txt");
        // Creates the line with username + password
        var usernamePassword = String.Format("Username: {0} Password: {1}", userNameBox.Text, passwordBox.Text);
        // Locates the user on your storage
        // This uses Linq syntax with lambda. Linq without lamba looks similar to SQL.
        // Lambda is a bit more advanced but reduces code-size and it's easier to understand (IMHO).
        // This code will iterate through users (list of string) and try to retrieve one that's equal to the contents of usernamePassword.
        var userFound = users.SingleOrDefault(_u => _u.Equals(usernamePassword));
        // If null, indicates that no username/password combination was found.
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
