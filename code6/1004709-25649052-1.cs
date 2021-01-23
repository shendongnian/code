    var x = new {
        Foo = "Bar",
        Baz = new Mutable<int>(2)
    };
    
    Console.WriteLine(x.Baz.Value); // 2
    x.Baz.Value++;
    Console.WriteLine(x.Baz.Value); // 3
