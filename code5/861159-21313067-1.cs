    //Mapper.CreateMap<SourceType, DestinationType2>(); -- don't want this!
    Mapper.CreateMap<SourceTypeB, DestinationType2>();
    //Mapper.CreateMap<SourceType, DestinationType1>(); -- don't want this!
    Mapper.CreateMap<SourceTypeA, DestinationType1>();
    var sourceTypes = new List<SourceType> { new SourceTypeA(), new SourceTypeB() };
    var destinationType1s = Mapper.Map<List<DestinationType1>>(sourceTypes.CompatibleMappedTypes<DestinationType1>());
    var destinationType2s = Mapper.Map<List<DestinationType2>>(sourceTypes.CompatibleMappedTypes<DestinationType2>());
...
    static class Extensions
    {
        public static IEnumerable CompatibleMappedTypes<TDestination>(this IEnumerable source)
        {
            foreach (var s in source)
            {
                if (Mapper.FindTypeMapFor(s.GetType(), typeof(TDestination)) != null) yield return s;
            }
        }
    }
