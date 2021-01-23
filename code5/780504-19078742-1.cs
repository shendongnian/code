    bool _ans;
    public bool checkUsernameNotExist()
    {
        string[] userNames = File.ReadAllLines(@"C:\Other\myFile.txt");
        foreach (string name in userNames)
        {
            if (name != userNameBox.Text)
            {                
                MessageBox.Show(
                     "Sorry, that user name is not available, try again",
                     "Invalid Username Entry");
                userNameBox.Text = "";
                passwordBox.Text = "";
                repeatPasswordBox.Text = "";
                _ans = false;
                return false;
            }
            else
                _ans = true;
                return true;
        }
        return _ans;
    }
