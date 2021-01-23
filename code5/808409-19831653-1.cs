    var foo1 = new Foo<int?>();
    Console.WriteLine(foo1.IsNull());
    var foo2 = new Foo<string>();
    Console.WriteLine(foo2.IsNull());
    var foo3= new Foo<int>();  // THROWS
    Console.WriteLine(foo3.IsNull());
