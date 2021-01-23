     public static void MapListIfNotEmpty<TSource, TMapFrom>(this IMemberConfigurationExpression<TSource> map,
            Func<TSource, IEnumerable<TMapFrom>> mapFrom)
        {
            map.Condition(src => !mapFrom(src).IsNullOrEmpty());
            map.MapFrom(mapFrom);
        }
