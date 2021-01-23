    var results = (from player in players
                   select new
                   {
                     PlayerId = player.Id,
                     PlayerName = player.Name,
                     Teams = teams.Where(t => player.TeamsIds.Contains(t.TeamId))
                                  .Select(t => new {
                                                       t.TeamId,
                                                       t.TeamName,
                                                       IsChecked = ???
                                                   }
                                  .ToList() 
                   });
