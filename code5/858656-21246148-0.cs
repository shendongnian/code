    public class AClass : IEnumerable<string>
    {
        public AClass()
        {
            this.values = new List<string>();
        }
    
        private readonly List<string> values;
    
        public void Add(string inputString)
        {
            this.values.Add(inputString);
        }
    
        public void Remove(string inputString)
        {
            this.values.Remove(inputString);
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        public IEnumerator<string> GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }
