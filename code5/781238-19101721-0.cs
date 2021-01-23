    public void mySW()
    {
        string path = @"C:\Other\myFile.txt";
        string userName = userNameBox.Text;
        string password = passwordBox.Text;
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine("Username: {0} Password: {1}", userName, password);
            // No need to close nor dispose your StreamWriter.
            // You're inside a using statement for that!
        }
        MessageBox.Show("Thanks for registering! \n\nYou may now log in!", "Registration SuccessFul");
        Application.OpenForms[0].Show();
        this.Close();
    }
