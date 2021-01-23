    private IEnumerable<Team> BuildTeams(IEnumerable<Team> allTeams,
                                                      int? parentId)
        {
            var teamTree = new List<Team>();
            var childTeams = allTeams.Where(o => o.ParentId == parentId).ToList();
            foreach (var team in childTeams)
            {
                var t = new Team();
                var children = BuildTeams(allTeams, team.TeamID);
                t.ChildTeams = children;
                teamTree.Add(t);
            }
            return teamTree ;
        }
