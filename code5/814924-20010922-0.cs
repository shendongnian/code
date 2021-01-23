    public interface IBaseRepository
    {
      T Get<T>(int id);
      void Save<T>(T entity);
    }
