    interface IDataStore<TStoreType> 
    {
        void SetBaseType(TStoreType obj);
        List<string> GetItems();
    }
    interface IDataStoreFactory
    {
        IDataStore<TStoreType> Create<TStoreType>(TStoreType obj) 
    }
    class DataStoreFactory : IDataStoreFactory
    {
        public IDataStore<TStoreType> Create<TStoreType>(TStoreType obj)
        {
            if (obj.GetType() == typeof(SqlConnection))
            {
                var store = new SQLDataStore((SqlConnection)(Object)obj);
                return (IDataStore<TStoreType>)store;
            }
            if (obj.GetType() == typeof(XmlDocument))
            { //... and so on }
        }
    }
    
    class SQLDataStore : IDataStore<SqlConnection>
    {
        private readonly SqlConnection connection;
        public SQLDataStore(SqlConnection connection)
        {
            this.connection = connection;
        }
        
        public List<string> GetItems() { return new List<string>(); }
    }
