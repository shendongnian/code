    internal class Foo
    {
        public Collection<string> Items { get; set; } // or List<string>
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            new Foo()
                {
                    Items = new Collection<string> { "foo" } // no longer throws NullReferenceException :-)
                };
        }
    }
