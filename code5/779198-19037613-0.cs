    public class Manager<T>
    {
        private Dictionary<int, T> IndexByID;
        private Dictionary<string, T> IndexByName;
        
        public T this[int index]
        {
            get { return this.IndexByID[index]; }
        }
        
        public T this[string index]
        {
            get { return this.IndexByName[index]; }
        }
        public void Add(int id, string name, T value)
        {
            this.IndexByID[id] = value;
            this.IndexByName[name] = value;
        }
    }
