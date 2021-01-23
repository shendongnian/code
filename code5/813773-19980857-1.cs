    var indexedEntities =
	   entities.Select((e, i) => new { Entity = e, Index = i })
	           .ToList();
	
    indexedEntities.ForEach(ie =>
       ie.Entity.UniqueId =
          indexedEntities.Any(prev => prev.Index < ie.Index)
         && ie.Entity.UniqueId
            <= indexedEntities.TakeWhile(prev => prev.Index < ie.Index)
                              .Max(prev => prev.Entity.UniqueId)
            ? indexedEntities.TakeWhile(prev => prev.Index < ie.Index)
                             .Max(prev => prev.Entity.UniqueId) + 1
            : ie.Entity.UniqueId);
    var result = indexedEntities.Select(ie => ie.Entity);
