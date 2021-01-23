    interface IDatabaseAdapter 
    {
        ITransactionScope CreateTransactionScope();
    }
    interface ITransactionScope : IDisposable
    {
        void Commit();
        void Rollback();        
    }
    class EntityFrameworkTransactionScope : ITransactionScope
    {
        private DbContextTransaction entityTransaction;
        EntityFrameworkTransactionScope(DbContextTransaction entityTransaction)
        {
            this.entityTransaction = entityTransaction;
        }
        public Commit() { entityTransaction.Commit(); }
        public Rollback() { entityTransaction.Rollback(); }
        public Dispose() { entityTransaction.Dispose(); }
        
    }
    class EntityFrameworkAdapterBase : IDatabaseAdapter
    {
       private Database database;
       protected EntityFrameworkAdapterBase(Database database)
       {
           this.database = database;
       }
       public ITransactionScope CreateTransactionScope()
       {
           return new EntityFrameworkTransactionScope(database.BeginTransaction());
       }
    }
    interface IIncidentDatabaseAdapter : IDatabaseAdapter
    {
        SaveIncident(Incident incident);
    }
    public EntityIncidentDatabaseAdapter : EntityFrameworkAdapterBase, IIncidentDatabaseAdapter
    {
        EntityIncidentDatabaseAdapter(Database database) : base(database) {}
        SaveIncident(Incident incident)
        {
             // code for saving the incident
        }
    }
