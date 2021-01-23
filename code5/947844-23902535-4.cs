    public partial class DataContext : ObjectContext
        {
            #region Constructors
        
            /// <summary>
            /// Initializes a new DataContext object using the connection string found in the 'DataContext' section of the application configuration file.
            /// </summary>
            public DataContext() : base("name=DataContext", "DataContext")
            {
                this.ContextOptions.LazyLoadingEnabled = true;
                OnContextCreated();
            }
        
            /// <summary>
            /// Initialize a new DataContext object.
            /// </summary>
            public DataContext(string connectionString) : base(connectionString, "DataContext")
            {
                this.ContextOptions.LazyLoadingEnabled = true;
                OnContextCreated();
            }
        
            /// <summary>
            /// Initialize a new DataContext object.
            /// </summary>
            public DataContext(EntityConnection connection) : base(connection, "DataContext")
            {
                this.ContextOptions.LazyLoadingEnabled = true;
                OnContextCreated();
            }
        
            #endregion
        
            #region Partial Methods
        
            partial void OnContextCreated();
        
            #endregion
        ...
        }
