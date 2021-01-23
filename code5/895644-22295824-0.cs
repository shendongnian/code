    using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Public\\Usernames.txt"))
    {
        file.WriteLine();
    }
    int userType = 0;
    string retrievedUsername = String.Empty;
    using (System.IO.StreamReader fileUsername = new System.IO.StreamReader("C:\\Users\\Public\\Usernames.txt"))
    {
        retrievedUsername = fileUsername.ReadToEnd();
    }
