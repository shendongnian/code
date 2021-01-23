    var agentGroups = finalResult
        .GroupBy(x => x.Agent)
        .Select(ag => new
        {
            Agent = ag.Key,
            ReasonCounts = ag.GroupBy(x => x.Reason)
                             .Select(g => new
                             {
                                 Agent = ag.Key,
                                 Reason = g.Key,
                                 Count = g.Sum(x => x.Count)
                             }).ToList(),
            Total_Count = ag.Sum(x => x.Count)
        });
    foreach (var agentGroup in agentGroups)
    {
        string agent = agentGroup.Agent;
        int totalCount = agentGroup.Total_Count;
        foreach (var reasonCount in agentGroup.ReasonCounts)
        {
            string reason = reasonCount.Reason;
            int count = reasonCount.Count;
        }
    }
