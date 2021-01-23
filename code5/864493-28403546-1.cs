    public class EntityRepository<T> : IQueryable<T> where T : class
    {
        private readonly ObjectSet<T> _objectSet;
        private InterceptingQueryProvider _queryProvider = null;
        public EntityRepository<T>(ObjectSet<T> objectSet)
		{
			_objectSet = objectSet;
		}
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _objectSet.AsEnumerable().GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _objectSet.AsEnumerable().GetEnumerator();
        }
        Type IQueryable.ElementType
        {
            get { return _objectSet.AsQueryable().ElementType; }
        }
        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _objectSet.AsQueryable().Expression; }
        }
        IQueryProvider IQueryable.Provider
        {
            get
            {
                if ( _queryProvider == null )
                {
                    _queryProvider = new InterceptingQueryProvider(_objectSet.AsQueryable().Provider);
                }
                return _queryProvider;
            }
        }
        // . . . . . you may want to include Insert(), Update(), and Delete() methods
	}
