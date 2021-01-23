    public static Expression<Func<User,int>> RoleCount()
    {
        return u => u.Roles.Count();
    }
    public static void DoStuff()
    {
        var roleCounter = RoleCount();
        var query = users.AsExpandable()
                         .Select(u => roleCounter(u));
    }
