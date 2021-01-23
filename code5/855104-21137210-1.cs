    public void loadData()
    {
        byte[] data = new byte[] { 0 }; // some byte data in here
        UsingConverter(data, x =>
        {
            // do work here...
        });
    }
    void UsingConverter(byte[] data, Action<MyDataConverter> action)
    {
        using (var stream = new MemoryStream(data))
        {
            var converter = new MyDataConverter(stream);
            action(converter);
        }
    }
