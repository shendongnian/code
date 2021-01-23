    private delegate int IntConverter<T>(T value);
    public void DoSomething<T>(T value)
    {
        DoCoreStuff(value, v => ConvertToIntInOneWay(v));
    }
    public void DoSomethingElse<T>(T value)
    {
        DoCoreStuff(value, v => ConvertToIntInAnotherWay(v));
    }
    private void DoCoreStuff<T>(T value, IntConverter<T> intConverter)
    {
        // Do a bunch of common stuff
        var intValue = intConverter(value);
        // Do a bunch of other core stuff, probably with the intValue
    }
