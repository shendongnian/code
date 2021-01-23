    internal class Foo
    {    
        internal Foo()
        {
            Items  = new Collection<string>();
        }
        public Collection<string> Items { get; private set; }
    }
    var foo = new Foo()
                    {
                        Items = { "foo" } // foo.Items contains 1 element "foo"
                    };
