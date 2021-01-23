    DbQuery().GroupBy(x => new {x.Name, x.Date, x.Age})
             .Select(g => new 
              {
                  g.Key.Name, 
                  g.Key.Date,
                  g.Key.Age, 
                  Locations = g.Select(x => new {x.Address, x.City, x.State})
              });
