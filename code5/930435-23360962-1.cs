    var entityBriefs = 
      Table<Operation>().Where(x => x.Date >= dateStart && x.Date < dateEnd)
                        .GroupBy(x => x.EntityId)
                        .OrderByDescending(x => x.Count())
                        .Take(5)
                        .ToList()
                        .Select(x => new EntityBrief
                        {
                            EntityId = x.Key.EntityId, 
                            Quantity = x.Count()
                        });
    var c = entityBriefs.ToDictionary(e => e.EntityId, e => e);
    var entityInfo = Table<Operation>().Where(o => mapping.Keys.Contains(o.EntityId).ToList();
    foreach(var entity in entityInfo)
    {
       mapping[entity.EntityId].EntityName = entity.EntityName;
       mapping[entity.EntityId].EntityToken = entity.EntityToken;
    }
 
