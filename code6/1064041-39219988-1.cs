    public class FooController
    {
       IRepository repository;
       public FooController(IService service, Func<string, IRepository> repositoryFactory)
       {
           repository = repositoryFactory("A");
       }
    }
