     public interface ISqlRepository<T>: IRepository<T> where T:class, IEntity
     {
          void Update(T item);
          void Attach(T item);
     }
