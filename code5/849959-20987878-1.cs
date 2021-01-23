    public class Foo
    {
        private static List<Foo> _instances = new List<Foo>();
        public Foo()
        {
            _instances.Add(this);
        }
        public static IEnumerable<Foo> Instances { get { return _instances; } }
    }
