        public MyDatabaseContext()
            : base("name=MyDatabaseContextEntities")
        {
        }
        public MyDatabaseContext(string connectionString)
            : base("name=MyDatabaseContextEntities")
        {
            this.Database.Connection.ConnectionString = connectionString;
        }
