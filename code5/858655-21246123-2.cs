    public class MyClass : IEnumerable
    {
        private List<string> myList;
        public MyClass()
        {
            myList = new List<string>();
        }
        public void Add(string item)
        {
            if (item != null) myList.Add(item);
        }
        public void Remove(string item)
        {
            if (myList.IndexOf(item) > 0) myList.Remove(item);
        }
        public IEnumerable<string> MyList { get { return myList; } }
        public IEnumerator GetEnumerator()
        {
            return myList.GetEnumerator();
        }
    }
