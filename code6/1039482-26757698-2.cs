    public class Repository<T> where T : class
    {
      internal T GetByIDImpl(int id, Func<T> factory)
      {
        ...
      }
    }
    public static class RepositoryExtensions
    {
      public T GetByID(this Repository<T> repo, int id) where T : class, new()
      {
        return repo.GetByIDImpl(id, () => new T());
      }
      public T GetByID(this Repository<T> repo, T element, int id) where T : class
      {
        return repo.GetByIDImpl(id, () => element);
      }
    }
