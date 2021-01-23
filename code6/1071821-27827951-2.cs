    class Program
    {
        static void Main(string[] args)
        {
            var root = new
            {
                Foo = new Foo
                {
                    Shared = new SharedClass
                    {
                        SomeValue = "foo1",
                        SomeOtherValue = "foo2"
                    }
                },
                Bar = new Bar
                {
                    Shared = new SharedClass
                    {
                        SomeValue = "bar1",
                        SomeOtherValue = "bar2"
                    }
                }
            };
            string json = JsonConvert.SerializeObject(root, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
