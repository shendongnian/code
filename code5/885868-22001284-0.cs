    class SomeBase<T> where T : DataObject, new()
    {
        public T Get(Guid id) where T : DataObject, new()
        {
            return Get(new T() { Id = id }).FirstOrDefault();
        }
        public List<T> Get(
            T condition,
            Boolean fuzzy = false,
            String order = null,
            Int32 limit = Int32.MaxValue,
            MyClass start = null) where T : DataObject
        {
            using (QueryBuilder qb = ResourceFinder.GetQueryBuilder()) {
                return qb.Find<T>(condition, fuzzy, order, limit, start);
            }
        }
        public List<T> Get(
            List<T> conditions,
            Boolean fuzzy = false,
            String order = null,
            Int32 limit = Int32.MaxValue,
            MyClass start = null) where T : DataObject
        {
            using (QueryBuilder qb = ResourceFinder.GetQueryBuilder()) {
                return qb.Find<T>(conditions, fuzzy, order, limit, start);
            }
        }
