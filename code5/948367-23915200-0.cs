    internal class Foo
    {
        public Foo()
        {
            this.Items = new Collection<string>();
        }
        public Collection<string> Items { get; set; } // or List<string>
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            new Foo()
                {
                    Items = { "foo" } // no longer throws NullReferenceException :-)
                };
        }
    }
