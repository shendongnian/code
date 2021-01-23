    class ListAdapter<T> : IList<T>
    {
        private readonly ICollection<T> backingStore;
        private readonly IList<T> list;
        public ListAdapter( ICollection<T> collection )
        {
            if ( collection == null ) throw new ArgumentNullException("collection");
            this.backingStore = collection ;
            this.list = collection as IList<T> ;
        }
        public int IndexOf( T item )
        {
            if ( list == null ) throw new NotSupportedException() ;
            return list.IndexOf(item) ;
        }
        public void Insert( int index , T item )
        {
            if ( list == null ) throw new NotSupportedException() ;
            list.Insert(index,item);
        }
        public void RemoveAt( int index )
        {
            if ( list == null ) throw new NotSupportedException() ;
            list.RemoveAt(index) ;
        }
        public T this[int index]
        {
            get
            {
                if ( list == null ) throw new NotSupportedException() ;
                return list[index] ;
            }
            set
            {
                if ( list == null ) throw new NotSupportedException() ;
                list[index] = value ;
            }
        }
        public void Add( T item )
        {
            backingStore.Add(item) ;
        }
        public void Clear()
        {
            backingStore.Clear() ;
        }
        public bool Contains( T item )
        {
            return backingStore.Contains(item) ;
        }
        public void CopyTo( T[] array , int arrayIndex )
        {
            backingStore.CopyTo( array , arrayIndex ) ;
        }
        public int Count
        {
            get { return backingStore.Count ; }
        }
        public bool IsReadOnly
        {
            get
            {
                if ( list == null ) throw new NotSupportedException() ;
                return list.IsReadOnly ;
            }
        }
        public bool Remove( T item )
        {
            return backingStore.Remove(item) ;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return backingStore.GetEnumerator() ;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)backingStore).GetEnumerator() ;
        }
    }
