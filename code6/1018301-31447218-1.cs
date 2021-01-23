    public static class SortedListEx
    {
        public static IEnumerable<KeyValuePair<K, V>> Tail<K, V>(this SortedList<K, V> list, K fromKey, bool inclusive = true)
        {
            http://stackoverflow.com/a/2948872/709537
            var binarySearchResult = list.Keys.BinarySearch(fromKey);
            if (binarySearchResult < 0)
                binarySearchResult = ~binarySearchResult;
            else if (!inclusive)
                binarySearchResult++;
            return new ListOffsetEnumerable<K, V>(list, binarySearchResult);
        }
    
        public static IEnumerable<KeyValuePair<K, V>> Head<K, V>(this SortedList<K, V> list, K toKey, bool inclusive = true)
        {
            http://stackoverflow.com/a/2948872/709537
            var binarySearchResult = list.Keys.BinarySearch(toKey);
            if (binarySearchResult < 0)
                binarySearchResult = ~binarySearchResult;
            else if (inclusive)
                binarySearchResult++;
            return System.Linq.Enumerable.Take(list, binarySearchResult);
        }
    
        class ListOffsetEnumerable<K, V> : IEnumerable<KeyValuePair<K, V>>
        {
            private readonly SortedList<K, V> _sortedList;
            private readonly int _offset;
    
            public ListOffsetEnumerable(SortedList<K, V> sortedList, int offset)
            {
                _sortedList = sortedList;
                _offset = offset;
            }
    
            public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
            {
                return new ListOffsetEnumerator<K, V>(_sortedList, _offset);
            }
    
            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }
        class ListOffsetEnumerator<K, V> : IEnumerator<KeyValuePair<K, V>>
        {
            private readonly SortedList<K, V> _sortedList;
            private int _index;
            
            public ListOffsetEnumerator(SortedList<K, V> sortedList, int offset)
            {
                _sortedList = sortedList;
                _index = offset - 1;
            }
    
            public bool MoveNext()
            {
                if (_index >= _sortedList.Count)
                    return false;
                _index++;
                return _index < _sortedList.Count;
            }
    
            public KeyValuePair<K, V> Current { get { return new KeyValuePair<K, V>(_sortedList.Keys[_index], _sortedList.Values[_index]); } }
            object IEnumerator.Current { get { return Current; } }
    
            public void Dispose() { }
            public void Reset() { throw new NotSupportedException(); }
        }
    }
