    public static UserTable checkUser(string userName, string password)
    {
        DemoEntities db = new DemoEntities();
        var query = (from u in db.UserTables
                     where u.UserName == userName && u.Password == password
                     select u).FirstOrDefault();
        if(query!=null)
            return query;
        else
            return null;
    }
