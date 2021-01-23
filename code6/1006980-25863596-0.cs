    foreach aEntity in aCollection
       aEntity.BEntity = bCollection.First(x=>x.Id == aEntity.bId);
    
    OR
    
    foreach bEntity in bCollection
       bEntity.AEntity.AddRange(aCollection.Where(x=>x.bId == bEntity.Id));
