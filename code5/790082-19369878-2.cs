    [Theory, AutoData]
    public void Test(Dummy dummy, string name)
    {
        dummy.Name = name;
        // ...
    }
