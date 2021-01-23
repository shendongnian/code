    public abstract BaseDao
    {
        public Connection GetNewConnection()
        {
            ....
        }
        // or similar functions which are used by DAOs accessing the same data source (DB, XML, ...)
    }
