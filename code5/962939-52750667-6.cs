    Model1 db = new Model1(); // Entity Framework context
    // States
    public IList<USERS> GetAllUsers()
    {
        return db.USERS.OrderBy(e => e.USER_ID).ToList();
    }
