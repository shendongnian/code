    public class MyEnumerable : IEnumerable<string>
    {
        private List<string> items;
        public IEnumerator<string> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
