    public class Map<TSource> where TSource : new()
    {
        public TSource Object { get; set; }
        public Map(TSource o)
        {
            Object = o;
        }
        public TDest To<TDest>()
        {
            var mapper = IocProxy.Container.Resolve<IMapper<TSource, TDest>>();
            return mapper.Map(Object);
        }
    }
