    public interface IRepositoryFactory {
      T Repository<T>();
    };
    public class NHibernateRepositoryFactory {
      T Repository<T>() {
        ..... // find class that implements T in Assemblies with reflection
        return repository;
      }
    };
    public static class Persistence {
      IRepositoryFactory Factory { get; set; }
    };
