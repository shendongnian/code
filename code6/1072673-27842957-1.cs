    public class Foo : IEnumerable<Bar>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<Bar> GetEnumerator()
        {
            //....
        }
    }
