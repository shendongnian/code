    public interface IMagicConverter
    {
        object ConvertIt(int input);
    }
    public interface IMagicConverter<T> : IMagicConverter
    {
        new T ConvertIt(int input);
    }
