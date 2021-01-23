    public static User GetUser(string Username)
    {
        using (Context DB = new Context())
        {               
            //This creates the instance of List<User> and gets the data (again, thanks Kristof!)
            return DB.Users.Include(x => x.Friends).SingleOrDefault(x => x.Username == Username);                   
        }
    }
