     public interface ISomeDataProvider
     {
         SomeType Find(int id); 
         ....
     }
     public class EfDataProvider : ISomeDataProvider
     {
         private SomeAppDbContext db = new SomeAppDbContext();
         public SomeType Find(int id){
             return db.SomeTypes.Find(id);
         }
     }
     public class AzureTableDataProvider : ISomeDataProvider
     {
         public SomeType Find(int id){
             return //Azure Table code
         }
     }
     public class CachingDataProvider : ISomeDataProvider
     {
         private ISomeDataProvider source;
         private static IList<SomeType> cache = new List<SomeType>(); //List used here, but could use .NET Cache, Redis, etc.
         public CachingDataProvider(ISomeDataProvider source){
                this.source = source;
         }
         public SomeType Find(int id){
             var result = cache.SingleOrDefault(x=>x.Id == id)
             if(result == null){
                 result = source.SingleOrDefault(x=>x.Id == id)
                 if(result != null) cache.Add(result); //Again, trivial cache example.  Cache expiration, refresh, loading, etc. should be considered per-app
             }
             return result
         }
     }
