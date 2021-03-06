    class MyContext : DbContext
    {
        bool _useInMemory;
        public MyContext(bool useInMemory)
        {
            _useInMemory = useInMemory;
        }
        protected override void OnConfiguring(DbContextOptions options)
        {
            if (_useInMemory)
            {
                options.UseInMemoryStore(persist: true);
            }
            else
            {
                options.UseSqlServer();
            }
        }
    }
