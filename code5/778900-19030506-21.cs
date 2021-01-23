        class Repo<T> where T : IPersisted<T>
        {
            //caching mechanism: this is run only once per instance; you can make it 
            //static if this shud be run only once the entire lifetime of application
            readonly T dummy = (T)FormatterServices.GetUninitializedObject(typeof(T));
            public IQueryable<T> Get()
            {
                return _queryable.Where(dummy.Predicate);
            }
        }
