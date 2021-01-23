    public int Height { get; private set; }
    public void OneMethod(int someValue)
    {
        // more code
        Height = someValue;
        // more code
    }
    public void AnotherMethod()
    {
        // more code
        someOtherObject.DoSomethingWithHeight(Height);
        // more code
    }
