    class ListDictionary<T1, T2> : Dictionary<T1, List<T2>>
    {
        public void Add(T1 key, T2 value)
        {
            if (this.ContainsKey(key))
            {
                this[key].Add(value);
            }
            else
            {
                List<T2> list = new List<T2>() { value };
                this.Add(key, list);
            }
        }
    }
