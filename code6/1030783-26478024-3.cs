        public class MyDbContext : DbContext
        {
            #region DBSet
            public DbSet<Models.Note> Notes { get; set; }
            #endregion
            #region Constructor
            public MyDbContext()
                : base("Data Source=" + HttpContext.Current.Server.MapPath("~/Bin/NotesExample.sdf"))
            {
                this.Configuration.AutoDetectChangesEnabled = true;
                this.Configuration.LazyLoadingEnabled = true;
                this.Configuration.ValidateOnSaveEnabled = true;
                this.Database.CreateIfNotExists();
            }
            #endregion
            #region Methods
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                NoteConfig noteConfig = new NoteConfig();
                modelBuilder.Configurations.Add(noteConfig);
                base.OnModelCreating(modelBuilder);
            }
            #endregion
        }
