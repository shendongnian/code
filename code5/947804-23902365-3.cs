    public class InvertedIndexCollection : IDictionary<string, List<int>>
    {
        public class IndexedWord
        {
            public string Key
            {
                get
                {
                    return kvp.Key;
                }
            }
            public List<int> Value
            {
                get
                {
                    return kvp.Value;
                }
            }
            private KeyValuePair<string, List<int>> kvp = new KeyValuePair<string, List<int>>();
            public IndexedWord()
            {
            }
            public IndexedWord(string _key, List<int> _newvalue)
            {
                kvp = new KeyValuePair<string, List<int>>(_key, _newvalue.OrderBy(x => x).ToList());
            }
        }
        private Dictionary<string, List<int>> Collection = new Dictionary<string, List<int>>();
        public int Count
        {
            get
            {
                return Collection.Count;
            }
        }
        public InvertedIndexCollection()
        {
        }
        public InvertedIndexCollection(Dictionary<string, List<int>> NewCollection)
        {
            Collection = NewCollection;
        }
        public List<int> this[string key]
        {
            get
            {
                return Collection[key];
            }
            set
            {
                Collection[key] = value;
            }
        }
        public void Add(IndexedWord NewItem)
        {
            if(Collection.ContainsKey(NewItem.Key))
                Collection[NewItem.Key].AddRange(NewItem.Value.Where(x => !Collection[NewItem.Key].Contains(x)));
            else
                Collection.Add(NewItem.Key, NewItem.Value);
        }
        public void Add(string Newkey, int Index)
        {
            if(Collection.ContainsKey(Newkey))
            {
                Collection[Newkey].Add(Index);
                Collection[Newkey].Sort();
            }
            else
                Collection.Add(Newkey, new List<int> { Index });
        }
        public List<int> FindIndices(string InputString, string Delimiter)
        {
            return FindIndices(InputString.Split(Delimiter.ToArray(), StringSplitOptions.RemoveEmptyEntries));
        }
        //This return a list of indices that contain all the search words.  You will
        //probably need to work out how to implement partial results, but this
        //should give you a start
        public List<int> FindIndices(IEnumerable<string> InputArray)
        {
            //Get a list of indices for each word
            var templist = (from word in InputArray
                            where Collection.ContainsKey(word)
                            select Collection[word]);
            //Flatten the lists and remove duplicates and return every index that is
            //common to all the words.
            return (from index in templist.SelectMany(x => x).Distinct()
                    where templist.All(x => x.Contains(index))
                    select index).ToList();
        }
        public void Add(string key, List<int> value)
        {
            Collection.Add(key, value);
        }
        public bool ContainsKey(string key)
        {
            return Collection.ContainsKey(key);
        }
        public ICollection<string> Keys
        {
            get
            {
                return Collection.Keys;
            }
        }
        public bool Remove(string key)
        {
            return Collection.Remove(key);
        }
        public bool TryGetValue(string key, out List<int> value)
        {
            return Collection.TryGetValue(key, out value);
        }
        public ICollection<List<int>> Values
        {
            get
            {
                return Collection.Values;
            }
        }
        public void Clear()
        {
            Collection.Clear();
        }
        public bool Contains(KeyValuePair<string, List<int>> item)
        {
            return Collection.Contains(item);
        }
        public IEnumerator<KeyValuePair<string, List<int>>> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
        public void Add(KeyValuePair<string, List<int>> item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<string, List<int>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public bool Remove(KeyValuePair<string, List<int>> item)
        {
            throw new NotImplementedException();
        }
    }
