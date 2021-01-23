    public static T Execute<T>(Func<otherLib.dbContext, T> f)
    {
        using (var db = new otherLib.dbContext())
            return f(db);
    }
