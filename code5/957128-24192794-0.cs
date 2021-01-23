    using (DBEntities de = new DBEntities())
    {
        string[] roleset = de.MySQLView
                             .Where(p => p.anotherfield == param)
                             .Select(p => p.RoleID)
                             .Distinct()
                             .AsEnumerable()
                             .Select(guid => guid.ToString())
                             .ToArray();
        return roleset;
    }
