    public class InvertedIndexCollection : Dictionary<string, List<int>>
    {
        public class Item
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
            Item()
            {
            }
            Item(string _key, List<int> _newvalue)
            {
                kvp = new KeyValuePair<string, List<int>>(_key, _newvalue.OrderBy(x => x).ToList());
            }
        }
        private Dictionary<string, List<int>> Collection = new Dictionary<string, List<int>>();
        InvertedIndexCollection()
        {
        }
        InvertedIndexCollection(Dictionary<string, List<int>> NewCollection)
        {
            Collection = NewCollection;
        }
        public void Add(Item NewItem)
        {
            if(Collection.ContainsKey(NewItem.Key))
                Collection[NewItem.Key].AddRange(NewItem.Value.Where(x => !Collection[NewItem.Key].Contains(x)));
            else
                Collection.Add(NewItem.Key, NewItem.Value);
        }
        public void Add(string NewKey, List<int> NewValue)
        {
            Collection.Add(NewKey, NewValue);
        }
        public List<int> FindIndices(string InputString, string Delimiter)
        {
            return FindIndices(InputString.Split(Delimiter.ToArray(),StringSplitOptions.RemoveEmptyEntries));
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
    }
