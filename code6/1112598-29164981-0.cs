    // Foo is assumed to be an entity / POCO
    public class Foo
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    // Decouple the Saver Service dependency via an interface
    public interface IFooSaverService
    {
        void Save(Foo aFoo);
    }
    // Implementation
    public class FooSaverService : IFooSaverService
    {
        public void Save(Foo aFoo)
        {
            // Persist this via ORM, Web Service, or ADO etc etc.
        }
        // Other non public methods here are implementation detail and not relevant to consumers
    }
    // Class consuming the FooSaverService
    public class FooController
    {
        private readonly IFooSaverService _fooSaverService;
        public FooController(IFooSaverService fooSaverService)
        {
            _fooSaverService = fooSaverService;
        }
        public void PersistTheFoo(Foo fooToBeSaved)
        {
            if (fooToBeSaved == null) throw new ArgumentNullException("fooToBeSaved");
            if (fooToBeSaved.ExpiryDate.Year > 2015)
            {
                _fooSaverService.Save(fooToBeSaved);
            }
        }
    }
