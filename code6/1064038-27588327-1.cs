    public class FooController
    {
       IRepository repository;
       public FooController(IService service, Func<IRepository> repositoryFactory)
       {
           repository = repositoryFactory("A");
       }
    }
