    public class MonarchDbContext:DbContext,IMonarchDbContext
    	{ 
               private IStoredProcedure m_storedProc;
           
               private static object m_dbIntializerSet;
           
    public MonarchDbContext(string nameOrConnectionString)
                : base( nameOrConnectionString )
            {
                //-- Set the DB initializer only once.
                System.Threading.LazyInitializer.EnsureInitialized( ref m_dbIntializerSet,()=>{
    									Database.SetInitializer<MonarchDbContext>(null);
                        //-- Give debug builds a chance to overwrite the above.
                        _SetInitializerForDebugBuilds();
                        return new object();
                    });
    
                Configuration.LazyLoadingEnabled = false;
                Configuration.ProxyCreationEnabled = false;
    
                var csb = new SqlConnectionStringBuilder( this.Database.Connection.ConnectionString );
           
    
    
                csb.MultipleActiveResultSets = true;
                this.Database.Connection.ConnectionString = csb.ToString();
    
                var objectContext = ( this as IObjectContextAdapter ).ObjectContext;
                objectContext.CommandTimeout = 3600;
            }
       #region Public "Tables"
    
            public IDbSet<DBBackupConfiguration> DBBackupConfigurations { get; set; }
           
            public IDbSet<DBBackupHistory> DBBackupHistorys { get; set; }
           
            public IStoredProcedure StoredProc
            {
                get
                {
                  
                    return System.Threading.LazyInitializer.EnsureInitialized(ref m_storedProc, () => new BackupStoredProc(this.Database));
                }
            }
            #endregion
