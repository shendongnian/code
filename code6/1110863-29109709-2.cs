    public class TranslatorDictionary
    {
        private readonly IDictionary<Type, IDictionary<Type, Delegate>> _mappings
            = new Dictionary<Type, IDictionary<Type, Delegate>>();
        public TDest Map<TSource, TDest>(TSource source)
        {
            IDictionary<Type, Delegate> typeMaps;
            Delegate theMapper;
            if (_mappings.TryGetValue(source.GetType(), out typeMaps) 
                && typeMaps.TryGetValue(typeof(TDest), out theMapper))
            {
                return (TDest)theMapper.DynamicInvoke(source);
            }
            throw new Exception(string.Format("No mapper registered from {0} to {1}", 
                typeof(TSource).FullName, typeof(TDest).FullName));
        }
        public void AddMap<TSource, TDest>(Func<TSource, TDest> newMap)
        {
            IDictionary<Type, Delegate> typeMaps;
            if (!_mappings.TryGetValue(typeof(TSource), out typeMaps))
            {
                typeMaps = new Dictionary<Type, Delegate>();
                _mappings.Add(typeof (TSource), typeMaps);
            }
            typeMaps[typeof(TDest)] = newMap;
        }
    }
