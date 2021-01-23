    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using TenantDataModel;
    
    namespace TenantDataContext
    {
        public class TenantDataCtx : DbContext, IDbModelCacheKeyProvider
        {
            #region Construction
    
            public static TenantDataCtx Create(string databaseServer, string databaseName, string databaseUserName, string databasePassword, Guid tenantId)
            {
                var connectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                connectionStringBuilder.DataSource = databaseServer;
                connectionStringBuilder.InitialCatalog = databaseName;
                connectionStringBuilder.UserID = databaseUserName;
                connectionStringBuilder.Password = databasePassword;
    
                string connectionString = connectionStringBuilder.ToString();
                return new TenantDataCtx(connectionString, tenantId);
            }
    
            // Used by EF migrations
            public TenantDataCtx()
            {
                Database.SetInitializer<TenantDataCtx>(null);
            }
    
            internal TenantDataCtx(string connectionString, Guid tenantId)
                : base(connectionString)
            {
                Database.SetInitializer<TenantDataCtx>(null);
                this.SchemaName = tenantId.ToString("D");
            }
    
            public string SchemaName { get; private set; }
    
            #endregion
    
            #region DataSet Properties
    
            public DbSet<TestEntity> TestEntities { get { return this.Set<TestEntity>(); } }
    
            #endregion
    
            #region Overrides
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                if (this.SchemaName != null)
                {
                    modelBuilder.HasDefaultSchema(this.SchemaName);
                }
    
                base.OnModelCreating(modelBuilder);
            }
    
            #endregion
    
            #region IDbModelCacheKeyProvider Members
    
            public string CacheKey
            {
                get { return this.SchemaName; }
            }
    
            #endregion
        }
    }
