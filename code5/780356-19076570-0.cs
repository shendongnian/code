    void Main()
    {
        var bill = new Person { FirstName = "Bill", TeamName = "Management" };
        var joe = new Person { FirstName = "Joe", Manager = bill, TeamName = "Management" };
        var scott = new Person { FirstName = "Scott", Manager = bill, TeamName = "Marketing" };
        var jim = new Person { FirstName = "Jim", Manager = bill, TeamName = "Technology" };
        var mark = new Person { FirstName = "Mark", Manager = scott, TeamName = "Marketing" };
        var bob = new Person { FirstName = "Bob", Manager = joe, TeamName = "Marketing" };
        var ted = new Person { FirstName = "Ted", Manager = jim, TeamName = "IT Support" };
    
        var people = new[] { bill, joe, scott, jim, mark, bob, ted };
        
        var teamParents = people.Select (p => new { Team = p.TeamName, ParentTeam = p.Manager == null ? null : p.Manager.TeamName });
        
        // don't let a team be its own parent
        teamParents = teamParents.Where (p => !p.Team.Equals(p.ParentTeam));
        
        // make sure they're all unique
        teamParents = teamParents.Distinct();
        
        // put it in a dictionary
        var teamHierarchy = teamParents.ToDictionary (p => p.Team, q => q.ParentTeam);
        
        foreach (string root in teamHierarchy.Where (h => h.Value == null).Select (h => h.Key))
        {    
            PrintSubteams(teamHierarchy, 0, root);
        }    
    }
    
    private void PrintSubteams(Dictionary<string, string> hierarchy, int level, string root)
    {
        for (int i = 0; i < level; i++)
        {
            Console.Write("    ");
        }
    
        Console.WriteLine(root);
        
        foreach (string child in hierarchy.Where (h => h.Value == root).Select(h => h.Key))
        {
            PrintSubteams(hierarchy, level + 1, child);
        }
    }
    
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string TeamName;
        public Person Manager;
        public IEnumerable<Person> DirectReports;
    }
