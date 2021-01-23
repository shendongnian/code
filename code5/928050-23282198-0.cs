    public IEnumerable<User> UserReadAll()
    {
     using (myEntities _db = new myEntities)
       { 
           return _db.Users.ToList();
       }
    }
