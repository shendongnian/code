    interface IApplicationDatabase
    {
        Foo GetFoo(int id);
    }
    class VistaDatabase : IApplicationDatabase
    {
        public Foo GetFoo(int id)
        {
            //do VistaDB-specific things to get the Foo
        }
    }
    class SqlServerDatabase : IApplicationDatabase
    {
        public Foo GetFoo(int id)
        {
            //do SQL Server-specific things to get the Foo
        }
    }
    class Demo
    {
        public Foo GetFooFromStorage(int id, IApplicationDatabase storage)
        {
            //notice here we don't need any separate code depending on the
            //concrete type of database
            return storage.GetFoo(id);
        }
    }        
