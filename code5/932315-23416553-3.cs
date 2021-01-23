    public List<string> GetClientAndPermittedActivities(int clientId)
    {
        var permittedActivities =
            ReadAllRaw()
                .Include("ClientType.Role.PermittedActivities")
                .Where(c => c.Id == clientId)
                .ToList();
    }
