    public class MyMapper {
    
         public static TDestination Map<TSource>(TSource source) 
         {
              if(TDestination.GetType() == TSource.GetType()) {
                   return source; //short-circuit here
              }
              return Mapper.Map<TSource>(source);
         }
         
         public static TDestination Map<TSource,TDestination>(TSource source, TDestination destination) 
         {
              if(TDestination.GetType() == TSource.GetType()) {
                   return source; //short-circuit here
              }
              return Mapper.Map<TSource, TDestination>(source, destination);
         }
    }
