     public class MyController(IEnumerable<IEntityRepository> repositories)
     {
        accountsRepo = repositories.Where(...);
        dataRepo = repositories.Where(...);
     }
