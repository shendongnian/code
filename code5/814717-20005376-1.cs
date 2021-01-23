    public static IEnumerable<TeamNode> CreateTree(IEnumerable<Team> allTeams)
    {
        var allNodes = allTeams.Select(team => new TeamNode() { Value = team })
            .ToList();
        var lookup = allNodes.ToLookup(team => team.Value.ParentTeamId);
        foreach (var node in allNodes)
            node.Children = lookup[node.Value.TeamId];
        return lookup[null];
    }
