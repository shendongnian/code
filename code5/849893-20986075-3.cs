    public bool Login(string username, string password)
    {
        var user = GetUser(username); //get the user from the database including the password hash and salt
        
        //hash the password provided in the login screen
        string pwdHash = HashPassword(password, user.PasswordSalt);
       return pwdHash.equals(user.PasswordHash);
    }
