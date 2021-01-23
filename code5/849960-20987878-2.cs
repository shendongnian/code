    public class Foo
    {
        private static List<WeakReference<Foo>> _instances = new List<WeakReference<Foo>>();
        public Foo()
        {
            _instances.Add(new WeakReference<Foo>(this));
        }
        public static IEnumerable<Foo> Instances
        {
            get
            {
                foreach(var r in _instances)
                {
                    Foo instance;
                    if (r.TryGetTarget(out instance))
                        yield return instance;
                }
            }
        }
    }
