    private void AddPersonToTeam(Person person, 
        Dictionary<string, Team> teamsByName)
    {
        Team matchingTeam;
        if (teams.TryGetValue(person.TeamName, out matchingTeam))
        {
            matchingTeam.PeopleInTeam.Add(person);
        }
        else
        {
            matchingTeam = new Team
            {
                TeamName = direct.TeamName
                PeopleInTeam = new List<Person>()
            };
            team.PeopleInTeam.Add(person);
            teams.Add(team.TeamName, team);
        }
    }
    public void ConstructTeams(IEnumerable<Person> topPeople,
        Dictionary<string, Team> teamsByName)
    {
        foreach (Person person in topPeople)
        {
            AddPersonToTeam(person, teamsByName);
            ConstructTeams(person.DirectReports, teamsByName);
        }
    }
