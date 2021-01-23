    var query = list.GroupBy(u => u.userID)                  
                    .Select(g => new {
                         userID = g.Key,
                         amountColumn = g.Count(),
                         randomColumn = g.First().randomColumn
                     }).OrderByDescending(x => x.amountColumn);
