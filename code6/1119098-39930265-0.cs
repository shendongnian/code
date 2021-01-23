    public class AutoMapperGenericsHelper<TSource, TDestination>
        {
            public static TDestination ConvertToDBEntity(TSource model)
            {
                Mapper.CreateMap<TSource, TDestination>();
                return Mapper.Map<TSource, TDestination>(model);
            }
        }
