    class Repository<TEntity> where TEntity : class, IEntity {
        void Add(TEntity entity);
    }
    
    class PeopleRepository : Repository<Person> {
        string GetPersonName();
    }
