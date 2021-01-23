    [Theory, InlineAutoData("SomeName")]
    public void Test(string name, Dummy dummy)
    {
        dummy.Name = name;
        // ...
    }
