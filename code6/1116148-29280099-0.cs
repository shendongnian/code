        public class Foo2 : MyInterface
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        
...
        var foo = doSomething<Foo2>("test");
        Console.WriteLine(foo.Name);
