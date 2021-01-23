        Func<T, K> _ordering;
        bool _ascending;
        public BaseINotifyCollectionChanged()
        {
        }
        public BaseINotifyCollectionChanged(Func<T, K> ordering, bool ascending = true)
        {
            _ordering = ordering;
            _ascending = ascending;
            OnCollectionChanged();
        }
        protected abstract IList<T> GetCollection();
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected void OnCollectionChanged()
        {
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void RaiseCollectionChanged()
        {
            OnCollectionChanged();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _ordering == null ? GetCollection().GetEnumerator() : _ascending ? GetCollection().OrderBy<T, K>(_ordering).GetEnumerator() :
                                                                                      GetCollection().OrderByDescending<T, K>(_ordering).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _ordering == null ? GetCollection().GetEnumerator() : _ascending ? GetCollection().OrderBy<T, K>(_ordering).GetEnumerator() :
                                                                                      GetCollection().OrderByDescending<T, K>(_ordering).GetEnumerator();
        }
    }
    }
