    var userNameFound = false;
    ar passwordMatches = false;
    try
    {
        var ndx = 0
        var passwords = File.ReadAllLines(passwordFile);
        foreach (var userName in File.ReadAllLines(usernameFile))
        {
            userNameFound = userName.Equals(textBox1.Text);
            if (userNameFound && ndx < passwords.Length)
            {
                passwordMatches = passwords[ndx].Equals(textBox2.Text);
                break; // no need to search further.
            }
            ndx++;
        }
    }
    catch (FileNotFoundException) 
    { 
        MessageBox.Show("Failed to open files", "Error");
    }    
    
