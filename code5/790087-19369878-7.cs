    [Theory, InlineAutoData("SomeName")]
    public void Test(string name, Dummy dummy)
    {
        ((IModifiableDummy)dummy).SetName(name);
        // ...
    }
