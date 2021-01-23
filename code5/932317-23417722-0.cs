    public List<string> GetClientAndPermittedActivities(int clientId)
    {
        return ReadAllRaw()
                .Where(c => c.Id == clientId)
                .SelectMany(
                               ct => ct.ClientType
                                       .Role
                                       .PermittedActivities,
                               (s, c) => c.Uid
                           )
                .ToList();
    }
