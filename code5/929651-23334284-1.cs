    IQueryable<User> basequery = from u in context.User 
                                 select u;
    if (accessCodes == null)
    {
        basequery = basequery.Where(u => u.AccessCode != null);
    }
    else
    {
        basequery = basequery.Where(u => accessCodes.Contains(u=>u.AccessCode));
    }
