    public class Fetch
    {
      public IQueryable<T> GetRecords<T>(int[] keys)
        where T : IKeyedByIntEntity
      {
        IQueryable<T> records = this.context.Where(e => keys.Contains(e.Key));
        return records;
      }
    }
    
    public class Fetch<T> where T : IKeyedByIntEntity
    {
      public IQueryable<T> GetRecords(int[] keys)
      {
        IQueryable<T> records = this.context.Where(e => keys.Contains(e.Key));
        return records;
      }
    }
