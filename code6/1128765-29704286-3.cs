    public class MyMapper
    {
    
            public static TDestination Map<TDestination>(object source) where TDestination : class
            {
                if(source is TDestination)
                {
                    return (TDestination) source; //short-circuit here
                }
    
                return Mapper.Map<TDestination>(source);
            }
    
    
            public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination) where TSource: class where TDestination: class
            {
                if(source is TDestination)
                {
                    return source as TDestination; //short-circuit here
                }
                return Mapper.Map<TSource, TDestination>(source, destination);
            }
    }
