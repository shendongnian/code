    public  class SecondClass
    {
        private readonly List<string> _collection = new List<string>();
        private string _lastFoldedString;
        private const string delimiter = ",";
        public virtual void AddString(string text)
        {
            // You'll need a lock if you have more than one concurrent writer
            // lock(_collection)
            {
               _collection.Add(text);
               // Or Use String.Join
               _lastFoldedString = _collection.Aggregate((i, j) => i + delimiter + j);
            }
        }
        public override string ToString()
        {
            return _lastFoldedString;
        }
    }
