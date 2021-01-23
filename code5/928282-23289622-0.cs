    private DbContext db;
    
    public bool IsDuplicate(string userName)
    {
        return db.Users.Any(u => u.UserName == userName);
    }
