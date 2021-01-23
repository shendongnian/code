    private struct ItemEnumerator<T> : IEnumerator<T>, IEnumerable<T> where T : Item
    {
        // Specific types for your unsafe internals
        // completely made up.
        private readonly SomeTypeOfCollectionHandle _handle;
        private SomeTypeOfCursor _cursor = SomeTypeOfCursor.BeforeAll;
        public ItemEnumerator(SomeTypeOfCollectionHandle handle)
        { 
            _handle = handle;
        }
        // IEnumerable<T> implementation.
        public IEnumerator<T> GetEnumerator()
        {
            // simply return a new instance with the same collection handle.
            return new ItemEnumerator(_handle);
        }
        public bool MoveNext()
        {
            return (cursor = _handle.CursorNext(_cursor)).IsValid();
        }
        public T Current
        { 
            get
            {
                if (!_cursor.IsValid())
                    throw new InvalidOperationException(); 
                return _cursor.Read<T>();
            }
        }
        object System.Collections.IEnumerator.Current
        {
            get { return (object)((IEnumerator<T>)this).Current; }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        public void Dispose()
        {
            _cursor = _handle.CloseCursor(_cursor);
        }
    }
