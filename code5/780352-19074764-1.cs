    public IEnumerable<Team> ConstructTeams(IEnumerable<Person> allPeople)
    {
        allPeople.GroupBy(person => person.TeamName)
            .Select(grouping => new Team
            {
                TeamName = grouping.Key,
                // I think this works, but IGroupings are weird and I don't
                // have a compiler with me
                PeopleInTeam = grouping.ToList()
            });
    }
