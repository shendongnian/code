    public class TestContext: IContext
    {
        public TestContext()
        {
            this.Systems = new TestSystemDbSet();
        }
        public DbSet<Models.System> Systems { get; set; }
        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        }
    }
