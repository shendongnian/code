        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Test2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DC1 : DbContext
    {
        public DbSet<Test1> Test1 { get; set; }
        public DC1(SqlConnection conn)
            : base(conn, contextOwnsConnection: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dc1");
            modelBuilder.Entity<Test1>().ToTable("Test1");
        }
    }
    public class DC2 : DbContext
    {
        public DbSet<Test2> Test2 { get; set; }
        public DC2(SqlConnection conn)
            : base(conn, contextOwnsConnection: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dc2");
            modelBuilder.Entity<Test2>().ToTable("Test2");
        }
    }
...
    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EntityConnectionString"].ConnectionString))
    {
        conn.Open();
        using (var tr = conn.BeginTransaction())
        {
            try
            {
                using (var dc1 = new DC1(conn))
                {
                    dc1.Database.UseTransaction(tr);
                    var t = dc1.Test1.ToList();
                    dc1.Test1.Add(new Test1
                    {
                        Name = "77777",
                    });
                    dc1.SaveChanges();
                }
                //throw new Exception();
                using (var dc2 = new DC2(conn))
                {
                    dc2.Database.UseTransaction(tr);
                    var t = dc2.Test2.ToList();
                    dc2.Test2.Add(new Test2
                    {
                        Name = "777777",
                    });
                    dc2.SaveChanges();
                }
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                //throw;
            }
            App.Current.Shutdown();
        }
    }
