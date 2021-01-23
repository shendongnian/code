    interface IRepository<EntityType<EntityKey>> {
      EntityType<EntityKey> Get(KeyType id);
    }
    
    interface PersonRepository : IRepository<Person> {
      Person Get(Int id);
    }
