    public void SomeMethod(string arg)
    {
        // throws ArgumentNullException if arg is null.
    }
    public void AnotherMethod([AllowNull] string arg)
    {
        // arg may be null here
    }
