    var results = (from player in players
                   select new
                   {
                     PlayerId = player.Id,
                     PlayerName = player.Name,
                     Teams = (from t in teams
                              where player.TeamsIds.Contains(t.TeamId)
                              select new {
                                             t.TeamId,
                                             t.TeamName,
                                             IsChecked = ???
                                         }
                             ).ToList() 
                   });
