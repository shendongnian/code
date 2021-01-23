    public class MyHistoryContext : HistoryContext 
    { 
        public MyHistoryContext(DbConnection dbConnection, string defaultSchema) 
            : base(dbConnection, defaultSchema) 
        { 
        } 
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<HistoryRow>().ToTable(tableName: "MigrationHistory", schemaName: "admin"); 
            modelBuilder.Entity<HistoryRow>().Property(p => p.MigrationId).HasColumnName("Migration_ID"); 
        } 
    } 
