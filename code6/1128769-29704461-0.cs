    // This is the example of my method
    private void ConversionExample<T>(IEnumerable<T> objs)
    {
        ...
    }
    
    // here is another method that will call this method.
    private void OtherMethod()
    {
        var strings = new List<string>();
        // This call works fine
        ConversionExample<string>(strings);
    
        var chars = new List<char>();
        // This should work now
        ConversionExample<char>(chars);
    }
