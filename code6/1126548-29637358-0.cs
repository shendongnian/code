      public class MyContext : DbContext
        {
            public MyContext() : base(new MyDbConnection(), true) {
                
            }
        }
    
        public class MyDbConnection : DbConnection
        {
            private SqlConnection connection;
    
            public MyDbConnection() {
                // init connection here
            }
    
            protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel) {
                return connection.BeginTransaction();
            }
    
            public override void Close() {
                connection.Close();
            }
    
            public override void ChangeDatabase(string databaseName) {
                connection.ChangeDatabase(databaseName);
            }
    
            public override void Open() {
                try {
                    connection.Open();
                }
                catch (Exception ex) {
                    throw new MyCustomException(this.ConnectionString, ex);
                }
            }
    
            public override string ConnectionString {
                get {
                    return this.connection.ConnectionString;
                }
                set {
                    this.connection.ConnectionString = value;
                }
            }
    
            public override string Database {
                get {
                    return this.connection.Database;
                }
            }
    
            public override ConnectionState State {
                get {
                    return this.connection.State;
                }
            }
    
            public override string DataSource {
                get {
                    return this.connection.DataSource;
                }
            }
    
            public override string ServerVersion {
                get {
                    return this.connection.ServerVersion;
                }
            }
    
            protected override DbCommand CreateDbCommand() {
                return this.connection.CreateCommand();
            }
        
