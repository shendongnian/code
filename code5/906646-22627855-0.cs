     var data = groupedByCategory1
             .GroupBy(co => co.Category1)
             .Select(grp => new 
                  {
                      Category1 = grp.Key// This is the key that you used to group
                      grp.ToList();//This will be the list of CustomObject
                  }
             .ToList(); 
