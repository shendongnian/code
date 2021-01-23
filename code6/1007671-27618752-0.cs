    using(dbEntity amadeus = new dbEntities())
    {
        if (entry.Key.ToString() == applicationName)
        {
            IRole role = entry.Value;
            role.StatusChange(userName);
        }
    }
