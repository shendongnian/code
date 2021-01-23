    public class Foo
    {
        public IReadOnlyList<int> l { get; private set; }
    
        public Foo(List<int> newList)
        {
            this.l = new ReadOnlyCollection<int>(newList.ToList());
        }
    }
