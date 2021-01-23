    Database db =   new Database (); 
    Transaction tx = db.BeginTransaction (); 
    try 
    { 
    // Read from the cache 
    MyEntity1 entity1 = cache.Get <MyEntity1> ("pk of entity1"); 
    // Cache is not read from the database 
     if (entity1 ==   null) entity1 = db.Get <MyEntity1> ("pk of entity1"); 
    // Entity1 processing 
    updated = db.Update, (entity1); / / entity1 update saved to the database 
     if (updated) cache.Put (entity1); / / database update successfully, the update cache 
    // Transaction processing 
    tx.commit (); 
    } 
    catch 
    { 
    tx.Rollback (); 
    throw; 
    }
