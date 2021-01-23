    public IEnumerable<Team> ConstructTeams(IEnumerable<Person> allPeople)
    {
        var teams = allPeople.GroupBy(person => person.TeamName)
            .Select(grouping => new Team
            {
                TeamName = grouping.Key,
                // I think this works, but IGroupings are weird and I don't
                // have a compiler with me
                PeopleInTeam = grouping.ToList()
            });
        // Set SubTeams
        // Group the teams by parent team. We assumed that
        // no team has two parent teams
        var teamsGroupedByParentTeam = teams
            .GroupBy(team => team.PeopleInTeam.First().TeamName);
        foreach (var groupOfTeams in teamsGroupedByParentTeam)
        {
            var parentTeam = teams.Single(team => team.TeamName == teamsGroupedByParentTeam.TeamName);
            parentTeam.SubTeams = groupOfTeams.ToList();
        }
        return teams;
    }
