    public class MyEntity { }
    public IEnumerable<MyEntity> MyEntitiesList { get { yield break; } }
    public IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> predicate)
    {
         if (typeof(T) == typeof(MyEntity))
         {
             return (IEnumerable<T>)MyEntitiesList.Where((predicate as Expression<Func<MyEntity, bool>>).Compile());
         }
         return new T[0];
    }
