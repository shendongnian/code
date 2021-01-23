    public class InvertedIndexCollection : Dictionary<string, List<int>>
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
        public new List<int> this[string key]
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
            return FindIndices(InputString.Split(Delimiter.ToArray(),StringSplitOptions.RemoveEmptyEntries));
        }
        public List<int> FindIndices(IEnumerable<string> InputArray)
        {
            var templist = (from word in InputArray
                            where Collection.ContainsKey(word)
                            select Collection[word]);
            return (from index in templist.SelectMany(x => x).Distinct()
                    where templist.All(x => x.Contains(index))
                    select index).ToList();
        }
    }
