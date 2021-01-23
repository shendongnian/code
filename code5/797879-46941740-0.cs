    interface IEntity
    {
        int Id {get;set;}
    }
    
    interface IUnitOfWork()
    {
        void RegisterNew(IRepsitory repository, IEntity entity);
        void RegisterDirty(IRepository respository, IEntity entity);
        //etc.
        bool Commit();
        bool Rollback();
    }
    
    interface IRepository<T>() : where T : IEntity;
    {
        void Add(IEntity entity, IUnitOfWork uow);
        //etc.
        bool CanCommit(IUnitOfWork uow);
        void Commit(IUnitOfWork uow);
        void Rollback(IUnitOfWork uow);
    }
