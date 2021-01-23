    // Fetch entities
    var entitiesDict = dbContext.DifferentEntity
         .Distinct(EqualityComparerForNameProperty).ToDictionary(e => e.Name); 
    
    // Create the new ones real quick and divide into groups of 500 
    // (cause that horse wins in my environment with complex entities, 
    // maybe 5 000 or 50 000 fits your scenario better since they are not that complex?)
    var newEnts = rates.AsParallel().Select((rate, index) => {
      new {
            Value = new YetAnotherEntity
               { Id = Guid.NewGuid(), DiffId = entitiesDict[rate.Name],},
            Index = index
         }
      })
    .GroupAdjacent(anon => anon.Index / 500) // integer division, and note GroupAdjacent! (not GroupBy)
    .Select(group => group.Select(anon => anon.Value)); // do the select so we get the ienumerables
    // Now we have to add them to the database
    Parallel.ForEach(groupedEnts, ents => {
       using (var db = new DBCONTEXT()) // your dbcontext
       {
         foreach(var ent in ents)       
           db.YetAnotherEntity.Add(ent);
         db.SaveChanges();
       }
    });
