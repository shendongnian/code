        class Repo<T> where T : IPersisted<T>
        {
            //caching mechanism
            static readonly Dictionary<Type, T> cache = new Dictionary<Type, T>();
            //run only once
            T dummy = cache.GetOrAdd(typeof(T), () => (T)FormatterServices.GetUninitializedObject(typeof(T)));
            public IQueryable<T> Get()
            {
                return _queryable.Where(dummy.Predicate);
            }
        }
        /// <param name="valueCreator">delegate rather than value itself for  
        /// performance reasons.</param>
        public static T GetOrAdd<S, T>(this IDictionary<S, T> dict, S key, Func<T> valueCreator)
        {
            T value;
            return dict.TryGetValue(key, out value) ? value : dict[key] = valueCreator();
        }
