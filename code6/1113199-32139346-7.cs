    // C# < 6
    public Constructor([NotNull] object foo)
    {
        Ensure.ArgumentNotNull(foo, "foo");
        ...
    }
    // C# >= 6
    public Constructor([NotNull] object bar)
    {
        Ensure.ArgumentNotNull(bar, nameof(bar));
        ...
    }
