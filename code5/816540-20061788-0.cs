        //ctors
        protected YOURDbContext(string connectionName)
            : base(connectionName) {
        }
        // YOU NEED THIS CONSTRUCTOR
        protected YOURDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection) {
        }
