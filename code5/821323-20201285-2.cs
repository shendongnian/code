    public class Inventory : IEnumerable<string>
    {
        private readonly int size;
        private const string emptyItem = "empty";
        private List<string> items = new List<string>();
        public Inventory(int size)
        {
            this.size = size;
        }
        public void Add(string item)
        {
            if (items.Count == size)
                throw new Exception("Inventory is full");
            items.Add(item);
        }
        public void Remove(string item)
        {
            items.Remove(item);
        }
        public IEnumerator<string> GetEnumerator()
        {
            return items.Concat(Enumerable.Repeat(emptyItem, size - items.Count))
                        .GetEnumerator();
        }
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
