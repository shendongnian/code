    // Note: all names changed to be more conventional
    public byte[] UniversalOperation<T>(T value)
    {
        dynamic d = value;
        return DynamicOperation(d);
    }
    private byte[] DynamicOperation<UKey, UValue>(CustomMap<UKey, UValue> map)
    {
        // Do stuff with the map here
    }
    private byte[] DynamicOperation<U>(U[] array)
    {
        // Do something with the array here
    }
    private byte[] DynamicOperation(object value)
    {
        // Fallback
    }
