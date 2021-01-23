    list<Entity> Entities = new list<Entity>(); //put all the database entities in here.
    List<AlteredEntity> AlteredEntities = new List<AlteredEntity>(); // for the new table
    foreach (Entity r in Entities)
    {
        AlteredEntity TempEnt = new AlteredEntity();
        AlteredEntity.Key = Convert.toint32(r.Key);
        AlteredEntity.Something = r.Something;
    }
    // iterate through AlteredEntities to input into the database
