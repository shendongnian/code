    obj.SomeB.SomeC.Foo = "bar";
    var getter = GetAccessor<A>("SomeB.SomeC.Foo");
    var setter = GetMutator<A>("SomeB.SomeC.Foo");
    Console.WriteLine(getter(obj)); // "bar"
    setter(obj, "baz");
    Console.WriteLine(getter(obj)); // "baz"
