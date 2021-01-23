       internal class Foo
        {    
            internal Foo()
            {
                Items  = new Collection<string>();
                Items.Add("foo1");
            }
            public Collection<string> Items { get; private set; }
        }
    
        var foo = new Foo()
                        {
                            Items = { "foo2" } // foo.Items contains 2 elements: "foo1", "foo2"
                        };
