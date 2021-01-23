    interface IEntity
    {
        int Id { get; }
        bool IsActive { get; set; }
    }
    
    interface IRepository<T>
        where T : IEntity
    {
        IQueryable<T> Get(bool includeInactiveEntities = false);
    }
