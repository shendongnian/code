    public static TOuput TryGenericParse<TInput, TOuput>(TInput input)
    {
        var converter = TypeDescriptor.GetConverter(typeof(TOuput));
        if (!converter.CanConvertFrom(typeof (TInput)))
            return default(TOuput);
        return (TOuput)converter.ConvertFrom(input);
    }
    bool bl = TryGenericParse<string, bool>("True");
    double dbl = TryGenericParse<string, double>("3.222");
