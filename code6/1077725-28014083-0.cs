    public class Foo : IFoo
    {
        private readonly IBar bar;
        public Foo (IBar bar) {
            this.bar = bar;
        }
    }
    public class Bar : IBar
    {
        private readonly IRepository repository;        
        public Bar(IRepository repository) {
            this.repository = repository;
        }
    }
    public class Repository : IRepository
    {
        private readonly IService service;        
        public Repository(IService service) {
            this.service = service;
        }
    }
