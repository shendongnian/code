    public class Team
    {
        int TeamID { get; set; }
        Team Parent; { get; set; }
    }
    
    public class TeamNode
    {
        public Team Node { get; set; }
        public IEnumerable<TeamNode> Children { get; set; }
    }
    private List<Team> BuildTeams(List<Team> allTeams, int? parentId)
    {
        List<TeamNodes> teamTree = new List<Team>();
        List<Team> childTeams;
        if (parentId == null)
        {
            childTeams = allTeams.Where(o => o.Parent == null).ToList();
            allTeams.RemoveAll(t => t.Parent == null);
        }
        else
        {
            childTeams = allTeams.Where(o => o.Parent.ID == parentId).ToList();
        }
        foreach (Team team in childTeams)
        {
            TeamNode teamNode = new Team();
            teamnode.Node = team;
            List<TeamNode> children = BuildTeams(allTeams, team.TeamID);
            teamNode.ChildTeams = children;
            teamTree.Add(t);
        }
        return teamTree ;
    }
