    // Note that this doesn't have to have params, but it can do
    public void Foo(object[] args)
    {
        // Whatever
    }
    ...
    ParamsAction action = Foo;
    action("a", 10, 20, "b");
