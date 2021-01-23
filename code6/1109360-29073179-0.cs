    var itemToAdd = As.Find(a1.Id);
    b.OwnedObjects.Add(itemToAdd);
    
    var itemToRemove = As.Find(a2.Id);
    b.OwnedObjects.Remove(itemToRemove);
    ChangeTracker.DetectChanges();
    SaveChanges();
