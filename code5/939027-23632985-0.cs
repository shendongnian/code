    class Factory<T> where T:new()
    {
        private Factory() { }
    
        private static Dictionary<string, T> Inventory = new Dictionary<string, T>();
    
        public static T GetObject(string key)
        {
            T result;
            if (Inventory.TryGetValue(key, out result) == false)
            {
                result = new T();
                Inventory.Add(key, result);
            }
            return result;
        }
    }
