    public bool checkUsernameNotExist()
    {
        bool exist = File.ReadAllLines(@"C:\Other\myFile.txt")
                         .Any(x=>x.StartsWith(userNameBox.Text+" "));
        if (exist)
        {
            MessageBox.Show(
                 "Sorry, that user name is not available, try again",
                 "Invalid Username Entry");
            userNameBox.Text = "";
            passwordBox.Text = "";
            repeatPasswordBox.Text = "";
        }
        return !exist;
    }
