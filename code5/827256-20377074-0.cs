    var query = Db.Players
                  .AsEnumerable //pulls all players into memory
                  .Select( p => new 
                  { 
                      Player      = p, 
                      TotalPoints = p.Matches.By(period).Sum(m => m.Points)
                  });
