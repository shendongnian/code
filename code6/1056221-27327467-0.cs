    public class Foo
    {
        public Foo(string something)
        {
            Something = something;
        }
        public string Something { set; get; }
    }
    public class BySomething : IComparer<Foo>
    {
        private readonly CaseInsensitiveComparer _comparer = new CaseInsensitiveComparer();
        public int Compare(Foo x, Foo y)
        {
            return _comparer.Compare(x.Something, y.Something);
        }
    }
