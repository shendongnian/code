    var name1 = CreatePropertyAccessor<Obj, string>("Name");
    var name2 = CreatePropertyAccessor<Obj, string>("Name2");
    var name3 = CreatePropertyAccessor<Obj, string>("Name3");
    var o = new Obj() // Obj is a type with those three properties
    {
        Name = "foo",
        Name2 = "bar",
        Name3 = "baz"
    };
    Console.WriteLine(name1(o)); // "foo"
    Console.WriteLine(name2(o)); // "bar"
    Console.WriteLine(name3(o)); // "baz"
