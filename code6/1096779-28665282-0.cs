    public class OrderedDictionary<T, K>
    {
        private Dictionary<T, K> baseDictionary;
        private Dictionary<long, T> entryTimeDictionary;
        public OrderedDictionary()
        {
            this.baseDictionary = new Dictionary<T, K>();
        }
        public void Add(T key, K val)
        {
            this.baseDictionary[key] = val;
            this.entryTimeDictionary[DateTime.Now.Ticks] = key;
        }
        public List<KeyValuePair<T, K>> GetLastEnteredItems(int numberOfEntries)
        {
            // Find n last keys.
            var lastEntries = 
                this.entryTimeDictionary
                    .OrderByDescending(i => i.Key)
                    .Take(numberOfEntries)
                    .Select(i => i.Value);
            // Return KeyValuePair for itmes with last n keys
            return this.baseDictionary
                       .Where(i => lastEntries.Contains(i.Key))
                       .ToList();
        }
    }
