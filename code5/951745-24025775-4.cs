    public class MyHistoryContext : HistoryContext
    {
        //We have to 'new' this as we are overriding the DbSet type
        public new DbSet<MyHistoryRow> History { get; set; }
        public MyHistoryContext(DbConnection dbConnection, string defaultSchema)
            : base(dbConnection, defaultSchema)
        {
        }
        //This part isn't needed but shows what you can do
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Rename the table and put it in a different schema. Our new table
            //will be called 'admin.MigrationHistory'
            modelBuilder.Entity<MyHistoryRow>().ToTable(tableName: "MigrationHistory", schemaName: "admin");
            //Rename one of the columns for fun
            modelBuilder.Entity<MyHistoryRow>().Property(p => p.MigrationId).HasColumnName("Migration_ID");
        }
    } 
