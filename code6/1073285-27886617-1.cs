    class Column
    {
        Dictionary<string, int> sums = new Dictionary<string, int>();
    
        public void Add(string data)
        {
            // First split on '/'.
            var dataSplitted = data.Split('/');
            foreach (var item in dataSplitted)
            {
                // Second split on '/'.
                var itemSplitted = item.Split(':');
                string name = itemSplitted[0];
                // Try to get the last sum and add the current value:
                int sum = 0;
                sums.TryGetValue(name, out sum );
                sums[name] = sum + int.Parse(itemSplitted[1]);
            }
        }
    
        // Creates a string from the sums.
        public override string ToString()
        {
            return 
                sums
                .Select(kvp => string.Format("{0}:{1}", kvp.Key, kvp.Value))
                .Aggregate((result, next) => result + "/" + next);
        }
    }
