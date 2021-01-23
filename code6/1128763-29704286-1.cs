    public class MyMapper
    {
         public static TDestination Map<TDestination>(object source)
         {
              if (typeof(TDestination) == source.GetType())
              {
                return (TDestination) source; //short-circuit here
              }
              return Mapper.Map<TDestination>(source);
         }
    }
