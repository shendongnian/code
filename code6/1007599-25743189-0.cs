    public class MyClass : IEnumerable<string>
    {
        private List<string> myList = new List<string>();
        public MyClass()
        {
            // Fill myList...
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return myList.GetEnumerator();
        }
        public IEnumerator<string> GetEnumerator()
        {
            return myList.GetEnumerator();
        }
    }
