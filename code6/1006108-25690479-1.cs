    public static void Foo(params object[] x)
    {
    }
    ...
    Action<object[]> func = Foo;
    func("a", 10, 20, "b"); // Invalid
    func(new object[] { "a", 10, 20, "b" }); // Valid
