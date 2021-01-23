        public void PopulateMissingValues(Dictionary<string, string> orig, Dictionary<string, string> newDict)
        {
            foreach (var pair in orig.Where(p => p.Value == string.Empty))
            {
                string newValue;
                if (newDict.TryGetValue(pair.Key, out newValue))
                    orig[pair.Key] = newValue;
            }
        }
