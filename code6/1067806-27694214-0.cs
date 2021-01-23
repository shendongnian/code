    public class FooBarRepo : IFooBarRepo
    {
        private readonly Entities _context;
        public FooBarRepo()
        {
            this._context = new Entities();
        }
        public IQueryable<FooBar> Get()
        {
            return this._context.FooBar;
        }
        public IQueryable<FooBar> GetIncludeFoo()
        {
            return this.Get().Include(i => i.Foo);
        }
        public IQueryable<FooBar> GetIncludeBar()
        {
            return this.Get().Include(i => i.Bar);
        }
        public IQueryable<FooBar> GetIncludeFooAndBar()
        {
            return this
                .Get()
                .Include(i => i.Foo)
                .Include(i => i.Bar);
        }
        public IQueryable<FooBar> GetIncludeFooAndChainBar()
        {
            return this.GetIncludeBar().Include(i => i.Foo);
        }
        public void Dispose()
        {
            this._context.Dispose();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<FooBar> get;
            IEnumerable<FooBar> getIncludeFoo;
            IEnumerable<FooBar> getIncludeBar;
            IEnumerable<FooBar> getIncludeFooAndBar;
            IEnumerable<FooBar> getIncludeFooAndChainBar;
            using (var context = new EntityFrameworkTesting.TestIncludeChaining.Repository.FooBarRepo())
            {
                get = context.Get().ToList();
                
				getIncludeFoo = context.GetIncludeFoo().ToList();
                
				getIncludeBar = context.GetIncludeBar().ToList();
                
				getIncludeFooAndBar = context.GetIncludeFooAndBar().ToList();
                
				getIncludeFooAndChainBar = context.GetIncludeFooAndChainBar().ToList();
            }
        }
    }
