    // States
    public IList<USERS> GetAllUsers()
    {
        return db.USERS.OrderBy(e => e.USER_ID).ToList();
    }
