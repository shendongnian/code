    [Theory, AutoData]
    public void Test(Dummy dummy, string name)
    {
        ((IModifiableDummy)dummy).SetName(name);
        // ...
    }
