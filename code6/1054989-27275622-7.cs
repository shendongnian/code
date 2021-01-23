    public interface IIntConverter<T>
    {
        int Convert(T value);
    }
    public void DoSomething<T>(T value)
    {
        DoCoreStuff(value, new ConvertToIntInOneWayIntConverter());
    }
    public void DoSomethingElse<T>(T value)
    {
        DoCoreStuff(value, new ConvertToIntInAnotherWayIntConverter());
    }
    private void DoCoreStuff<T>(T value, IIntConverter<T> intConverter)
    {
        // Do a bunch of common stuff
        var intValue = intConverter.Convert(value);
        // Do a bunch of other core stuff, probably with the intValue
    }
