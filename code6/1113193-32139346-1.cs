    // C# < 6
    public Constructor(object argument)
    {
        Ensure.ArgumentNotNull(foo, "foo");
        ...
    }
    // C# >= 6
    public Constructor(object bar)
    {
        Ensure.ArgumentNotNull(bar, nameof(bar));
        ...
    }
