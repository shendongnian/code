    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace _20611500
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyCustomDictionary<int, List<int>> myCustomDict = new MyCustomDictionary<int, List<int>>();
                var someElementThatIsNotFound = myCustomDict[1]; // this will return a new List because a key of 1 was not found
            }
        }
    
        class MyCustomDictionary<TKey, TValue> : IDictionary<TKey, TValue>
            where TValue : class, new()
        {
            private Dictionary<TKey, TValue> _dictionary;
    
            public MyCustomDictionary()
            {
                _dictionary = new Dictionary<TKey, TValue>();
            }
            public TValue this[TKey key] // this is the important part here
            {
                get
                {
                    if (_dictionary.ContainsKey(key)) // if it did see the element, return it
                    {
                        return _dictionary[key];
                    }
                    else // else add a new element and return that new element
                    {
                        _dictionary.Add(key, new TValue());
                        return _dictionary[key];
                    }
                }
                set
                {
                    _dictionary[key] = value;
                }
            }
    
            public void Add(TKey key, TValue value)
            {
                _dictionary.Add(key, value);
            }
    
            public bool ContainsKey(TKey key)
            {
                return _dictionary.ContainsKey(key);
            }
    
            public ICollection<TKey> Keys
            {
                get { return _dictionary.Keys; }
            }
    
            public bool Remove(TKey key)
            {
                return _dictionary.Remove(key);
            }
    
            public bool TryGetValue(TKey key, out TValue value)
            {
                return _dictionary.TryGetValue(key, out value);
            }
    
            public ICollection<TValue> Values
            {
                get { return _dictionary.Values; }
            }
    
            public void Add(KeyValuePair<TKey, TValue> item)
            {
                _dictionary.Add(item.Key, item.Value);
            }
    
            public void Clear()
            {
                _dictionary.Clear();
            }
    
            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                return _dictionary.Contains(item);
            }
    
            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                throw new NotImplementedException(); // do you need this? you can leave this :)
            }
    
            public int Count
            {
                get { return _dictionary.Count; }
            }
    
            public bool IsReadOnly
            {
                get { return false; }
            }
    
            public bool Remove(KeyValuePair<TKey, TValue> item)
            {
                return _dictionary.Remove(item.Key);
            }
    
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                return _dictionary.GetEnumerator();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _dictionary.GetEnumerator();
            }
        }
    }
