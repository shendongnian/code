    public class FooController
    {
        public FooController(IService service, [Dependency("A")] IRepository repository)
        {
        }
    }
    
    public class BarController
    {
        public BarController(IService service, [Dependency("B")] IRepository repository)
        {
        }
    }
