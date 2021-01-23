    string password = "";
    if(InitialPassword)
    {
        password = PasswordTxt.Text;
        password = password.Substring(0, password.Length - addStars.Length);
    }  
    else
    {
        password = PasswordTxt.Text;
    }
