    class Foo
    {
        public Dictionary<string, string> values = new Dictionary<string, string>();
    
        public Foo()
        {
            values["foo"] = "test";
        }
    }
    
    var test = "foo";
    var foo = new Foo();
    Console.WriteLine(foo.values[test]);
