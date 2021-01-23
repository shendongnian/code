    internal class Foo
    {
        public Foo(){Items = new Collection(); }
        public Collection<string> Items { get; set; } // or List<string>
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            new Foo()
                {
                    Items = { "foo" } // throws NullReferenceException
                };
        }
    }
