    public User getUser(string login, string password)
    {
        var query = (from c in dataContext.Users
                     where c.username == login && c.password == password
                     select c);
        return query.GetFirstOrException();
    }
    public HardwareConfiguration getHardwareConfiguration(int id)
    {
        var query = (from c in dataContext.HardwareConfigurations
                     where c.ID == id
                     select c);
        return query.GetFirstOrException();
    }
