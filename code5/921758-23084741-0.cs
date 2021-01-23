    public bool InsertDefaultUser()
    {
        try
        {
           Guild_Chat.User newUser = new Guild_Chat.User
                                  {
                                     alias = "bulby",
                                     password = "chicken",
                                     email = "r@hot.com"
                                  };
           dbc.Users.AddObject(newUser);
           dbc.SaveChanges();
           return true;
        }
        catch(Exception e)
        {
           return false;
        }
    }
