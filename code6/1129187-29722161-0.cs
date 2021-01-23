    private struct ItemEnumeratorWrapper<T> : IEnumerable<T> where T : Item
    {
        private ItemCollection _collection;
        public ItemEnumeratorWrapper<T>(ItemCollection collection)
        {
            _collection = collection;
        }
        public ItemEnumerator<T> GetEnumerator()
        {
            return _collection.GetItemsOfTypeEnumerator<T>();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
