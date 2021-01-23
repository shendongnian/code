    private static string GetAccessCode()
    {
        using (EPOSEntities db = new EPOSEntities())
        {
            return db.ClientAccountAccesses
                     .Where(e => String.IsNullOrWhiteSpace(e.GUID))
                     .Select(e => e.GUID)
                     .FirstOrDefault();
        }
    }
