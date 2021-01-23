    public List<string> GetClientAndPermittedActivities(int clientId)
    {
        var permittedActivities =
            ReadAllRaw().Include(x => c.ClientType.Role.PermittedActivities.SelectMany(pa => pa.Activities.Uid))
                .Where(c => c.Id == clientId)
                .ToList();
    }
