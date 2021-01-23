    public class MyCollection : IEnumerable<MyType>
    {
        private IEnumerable<MyType> _list;
        public MyCollection(IEnumerable<MyType> collection)
        {
            _list = collection;
        }
        // collection methods excluded for brevity
        public MyCollection Filter(string filter)
        {
            return new MyCollection(_list.Where(obj => obj.Filter.Equals(filter))); 
        }
