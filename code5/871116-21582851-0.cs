    abstract class RepositoryBase<TEntity> where TEntity : class, IEntity {
        void Add(TEntity entity);
        ...
    }
    
    class PeopleRepository : RepositoryBase<Person> {
        string GetPersonName();
    }
    
    class SpaceshipRepository : RepositoryBase<Spaceship> {
        void Fly();
    }
