        public string MatchResult (object Result) {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        DOTA2DataContext db = new DOTA2DataContext();
        var Victory = Result;
        var TeamId = db.PlayerMatches.Where(x => x.TeamId == id);
        var WinningTeam = db.Matches.Where(x => x.WinningTeamId == id);
        {
            if (TeamId == WinningTeam)
            { 
                return "Won match";
            }
            else
            {
                return "Lost match";
            }
        }
    }
