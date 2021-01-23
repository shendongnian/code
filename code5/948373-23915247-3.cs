    internal class Foo
    {    
        internal Foo()
        {
            Items  = new Collection<string>();
        }
        public Collection<string> Items { get; private set; }
    }
