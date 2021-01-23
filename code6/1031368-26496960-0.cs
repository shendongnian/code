    private static List<IEnumerable<object>> AllEntities(MyEntities db)
    {
        List<IEnumerable<object>> list = new List<IEnumerable<object>>();
        list.Add(db.UserRole);
        list.Add(db.UserAccountRole);
        list.Add(db.UserAccount);
        return list;
    }
