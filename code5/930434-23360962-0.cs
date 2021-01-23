    var entityBriefs = 
     Table<Operation>().Where(x => x.Date >= dateStart && x.Date < dateEnd)
                       .GroupBy(x => new
                        {
                           x.EntityId, 
                           x.EntityName, 
                           x.EntityToken
                        })
                        .OrderByDescending(x => x.Count())
                        .Take(5)
                        .Select(x => new EntityBrief
                        {
                            EntityId = x.Key.EntityId, 
                            EntityName = x.Key.EntityName, 
                            EntityToken = x.Key.EntityToken, 
                            Quantity = x.Count()
                        });
