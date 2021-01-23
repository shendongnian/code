    public void ConstructTeams(IEnumerable<Person> topPeople,
        Dictionary<string, Team> teamsByName)
    {
        foreach (Person person in topPeople)
        {
            // Add person to their team. Create one if it doesn't exist
            Team matchingTeam;
            if (teamsByName.TryGetValue(person.TeamName, out matchingTeam))
            {
                matchingTeam.PeopleInTeam.Add(person);
            }
            else
            {
                // Create a new team and update its parent team
                matchingTeam = new Team
                {
                    TeamName = direct.TeamName
                    PeopleInTeam = new List<Person>()
                };
                matchingTeam.PeopleInTeam.Add(person);
                teamsByName.Add(matchingTeam.TeamName, matchingTeam);
                // The manager's team should already exist because we traversing the
                // Person tree/forest from the roots to the leaves
                if (person.Manager != null)
                {
                    teamsByName[person.Manager.TeamName].SubTeams.Add(matchingTeam);
                }
            }
            // Recursively fill in the direct reports
            ConstructTeams(person.DirectReports, teamsByName);
        }
    }
