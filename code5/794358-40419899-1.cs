    public class IntegrationDbContext : DbContext, IDbModelCacheKeyProvider
    {
        private static readonly ILog __log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Factory method
        /// </summary>
        public static IntegrationDbContext Create(string connectionStringName)
        {
            return new IntegrationDbContext(connectionStringName, GetDBSchema(connectionStringName));
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public IntegrationDbContext()
        {
            Database.SetInitializer<IntegrationDbContext>(null);
        }
        /// <summary>
        /// Constructor
        /// </summary>
        internal IntegrationDbContext(string connectionString, string schemaName)
            : base("name={0}".Fill(connectionString))
        {
            Database.SetInitializer<IntegrationDbContext>(null);
            SchemaName = schemaName;
        }
        /// <summary>
        /// DB schema name
        /// </summary>
        public string SchemaName { get; private set; }
        #region Tables
        /// <summary>
        /// Integration table "SYNC_BONUS_DISTRIBUTION"
        /// </summary>
        public virtual DbSet<SYNC_BONUS_DISTRIBUTION> SYNC_BONUS_DISTRIBUTION { get; set; }
        /// <summary>
        /// Integration table "SYNC_MESSAGE_DISTRIBUTION"
        /// </summary>
        public virtual DbSet<SYNC_MESSAGE_DISTRIBUTION> SYNC_MESSAGE_DISTRIBUTION { get; set; }
        /// <summary>
        /// Integration table "IMPORT_TEMPLATES"
        /// </summary>
        public virtual DbSet<IMPORT_TEMPLATE> IMPORT_TEMPLATES { get; set; }
        #endregion //Tables
        private static Dictionary<string, string> __schemaCache = new Dictionary<string, string>();
        private static object __schCacheLock = new object();
        /// <summary>
        /// Gets DB schema name from connection string, or default from config
        /// </summary>
        private static string GetDBSchema(string connectionStringName)
        {
            string result;
            if (!__schemaCache.TryGetValue(connectionStringName, out result))
            {
                lock (__schCacheLock)
                {
                    if (!__schemaCache.TryGetValue(connectionStringName, out result))
                    {
                        DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
                        builder.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                        result = builder.ContainsKey("User ID") ? builder["User ID"] as string : ConfigurationManager.AppSettings["DefaultIntegrationSchema"];
                        __schemaCache.Add(connectionStringName, result);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Context initialization
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            __log.DebugFormat("OnModelCreating for integration model in schema: {0}", SchemaName);
            if (SchemaName != null)
            {
                modelBuilder.HasDefaultSchema(SchemaName);
            }
            //### CLOB settings
            modelBuilder.Properties().Where(p => p.PropertyType == typeof(string) &&
                                                 p.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length == 0)
                                                    .Configure(p => p.HasMaxLength(2000));
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// Implementation of <see cref="IDbModelCacheKeyProvider.CacheKey"/> - thanks by this is 'OnModelCreating' calling for each specific schema.
        /// </summary>
        public string CacheKey
        {
            get { return SchemaName; }
        }
    }
