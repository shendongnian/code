     public bool checkUsernameNotExist()
        {
            string readfile = System.IO.File.ReadAllText(@"C:\file.txt");
            userlist.Text = readfile;
            for (int i = 0; i < userlist.Lines.Length; i++)
            {
                string line = userlist.Lines[i];
                if (line.Contains("Username: " + userNameBox.Text))
                {
                    MessageBox.Show("Sorry, that user name is not available, try again", "Invalid Username Entry");
                    userNameBox.Text = "";
                    passwordBox.Text = "";
                    repeatPasswordBox.Text = "";
                    return false;
                }
                else
                    return true;
            }
