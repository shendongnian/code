    public static class RepositoryExtensions
    {
      public T GetByID(this Repository<T> repo, int id) where T : class, new()
      {
        ...
      }
    }
