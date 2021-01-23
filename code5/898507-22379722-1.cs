    obj.SomeB.SomeC.Foo = "bar";
    var pa = new PropertyAccessor("SomeB.SomeC.Foo");
    Console.WriteLine(pa.Get(obj)); // "bar"
    pa.Set(obj, "baz");
    Console.WriteLine(pa.Get(obj)); // "baz"
