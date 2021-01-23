    // current syntax
    class PersonRepository : IRepository<int, Person>
    {
        public Person Get(int id) { ... }
    }
    // proposed syntax
    class PersonRepository : IRepository<EntityType: Person>
    {
        public Person Get(int id) { ... }
    }
