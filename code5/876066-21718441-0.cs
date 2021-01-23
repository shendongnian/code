    string[] lineOfContents = File.ReadAllLines(@"C:\users.csv");
    string email="ed@yahoo.com";
    if (lineOfContents.Contains(email))
    {  
        MessageBox.Show("Email already exists");
    }
    else
    {
        MessageBox.Show("Ok");
    }
