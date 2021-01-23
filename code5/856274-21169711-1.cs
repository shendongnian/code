    public static List<User> GetUser(string value, string fieldName)
    {
        var db = new CCPTDataContext();
        return db.Users.Where(GetPropertyContainsValueExpression<User>(fieldName, value)).ToList();
    }
