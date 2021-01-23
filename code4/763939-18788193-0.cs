    public class FilteredCollection <TEntity> : ICollection<TEntity> where TEntity : Entity
    {
        private readonly DbCollectionEntry _dbCollectionEntry;
        private readonly Func<TEntity, Boolean> _compiledFilter;
        private readonly Expression<Func<TEntity, Boolean>> _filter;
        private ICollection<TEntity> _collection;
        private int? _cachedCount;
        public FilteredCollection(ICollection<TEntity> collection, DbCollectionEntry dbCollectionEntry)
        {
            _filter = entity => !entity.Deleted;
            _dbCollectionEntry = dbCollectionEntry;
            _compiledFilter = _filter.Compile();
            _collection = collection != null ? collection.Where(_compiledFilter).ToList() : null;
        }
        
        private ICollection<TEntity> Entities
        {
            get
            {
                if (_dbCollectionEntry.IsLoaded == false && _collection == null)
                {
                    IQueryable<TEntity> query = _dbCollectionEntry.Query().Cast<TEntity>().Where(_filter);
                    _dbCollectionEntry.CurrentValue = this;
                    _collection = query.ToList();
                    object internalCollectionEntry =
                        _dbCollectionEntry.GetType()
                            .GetField("_internalCollectionEntry", BindingFlags.NonPublic | BindingFlags.Instance)
                            .GetValue(_dbCollectionEntry);
                    object relatedEnd =
                        internalCollectionEntry.GetType()
                            .BaseType.GetField("_relatedEnd", BindingFlags.NonPublic | BindingFlags.Instance)
                            .GetValue(internalCollectionEntry);
                    relatedEnd.GetType()
                        .GetField("_isLoaded", BindingFlags.NonPublic | BindingFlags.Instance)
                        .SetValue(relatedEnd, true);
                }
                return _collection;
            }
        }
        #region ICollection<T> Members
        void ICollection<TEntity>.Add(TEntity item)
        {
            if(_compiledFilter(item))
                Entities.Add(item);
        }
        void ICollection<TEntity>.Clear()
        {
            Entities.Clear();
        }
        Boolean ICollection<TEntity>.Contains(TEntity item)
        {
            return Entities.Contains(item);
        }
        void ICollection<TEntity>.CopyTo(TEntity[] array, Int32 arrayIndex)
        {
            Entities.CopyTo(array, arrayIndex);
        }
        Int32 ICollection<TEntity>.Count
        {
            get
            {
                if (_dbCollectionEntry.IsLoaded)
                    return _collection.Count;
                return _dbCollectionEntry.Query().Cast<TEntity>().Count(_filter);
            }
        }
        Boolean ICollection<TEntity>.IsReadOnly
        {
            get
            {
                return Entities.IsReadOnly;
            }
        }
        Boolean ICollection<TEntity>.Remove(TEntity item)
        {
            return Entities.Remove(item);
        }
        #endregion
        #region IEnumerable<T> Members
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return Entities.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ( ( this as IEnumerable<TEntity> ).GetEnumerator() );
        }
        #endregion
    }
