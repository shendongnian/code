    var query = users.GroupBy(u => u.userID)                  
                     .Select(g => new {
                         UserID = g.Key,
                         AmountColumn = g.Count(),
                         RandomColumn = g.First().RandomColumn
                      }).OrderByDescending(x => x.AmountColumn)
