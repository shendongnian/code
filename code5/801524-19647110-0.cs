    // Return true if is in valid e-mail format.
    public static bool IsValidEmail( string sEmail )
    {		
        return Regex.IsMatch(sEmail, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
    }
