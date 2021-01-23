    var userNameFound = false;
    ar passwordMatches = false;
    try
    {
        foreach (var userName in File.ReadAllLines(usernameFile))
        {
            foreach (var password in File.ReadAllLines(usernameFile))
            {
                userNameFound = userName == textBox1.Text;
                if (userNameFound)
                {
                    passwordMatches = password == textBox2.Text;
                    break; // no need to search further.
                }
            }
        }
    }
    catch (FileNotFoundException) 
    { 
        MessageBox.Show("Failed to open files", "Error");
    }    
    
