    public class Repository<T> where T : IMappable, new()
    {
         public virtual List<IMappable> Get()
         {
              T mapper = new T();
              return new DataProvider().Get(mapper.Map);
         }
    }
