    IEnumerable<INamable> list = new List<Foo>
                                 {
                                   new Foo() {Id = 1, Name = "FooName1", Surname = "FooSurname1"},
                                   new Foo() {Id = 2, Name = "FooName2", Surname = "FooSurname2"}
                                 };
    ExtractUsingInterface(list);
    // IEnumerable<object> list... will be fine for both solutions below
    ExtractUsingReflection(list);
    ExtractUsingDynamic(list);
