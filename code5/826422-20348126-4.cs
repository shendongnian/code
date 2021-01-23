    public void SomeFunc(string value)
    {
        value.ThrowIfDefault("value");
    }
    public void MyFunc(Guid guid)
    {
        guid.ThrowIfDefault("guid");
    }
