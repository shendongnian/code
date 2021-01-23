    public class MyEntity { public int x; }
    MyEntity[] MyEntitiesList = Enumerable.Range(1,5).Select(y => new MyEntity() { x = y }).ToArray();
    public IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> predicate)
    {
         if (typeof(T) == typeof(MyEntity))
         {
             return (IEnumerable<T>)MyEntitiesList.Where((predicate as Expression<Func<MyEntity, bool>>).Compile());
         }
         return new T[0];
    }
