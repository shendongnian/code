    public string Authenticateuser(string Username, string Auth)
    {
        var User = UserList.FirstOrDefault(t => t.UName.Contains(Username));
        if(User != null)    
           return User.UName;
        else  //user not found
           return null;//throw exception / Message etc
    }
