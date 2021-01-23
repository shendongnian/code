       public interface IRepositoryContainer
       {
          IRepository GetRepository<T>() where T : IRepository;
       }
       public partial class App : Application, IRepositoryContainer
       {
          private List<IRepository> repositories =
             new List<IRepository>() { new MyRespository() };
    
          public IRepository GetRepository<T>() 
             where T : IRepository
          {
             return repositories.Where(t => t is T).SingleOrDefault();
          }
