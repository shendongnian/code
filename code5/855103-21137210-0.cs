    public void loadData()
    {
        byte[] data = new byte[] { 0 }; // some byte data in here
        using (var stream = new MemoryStream(data))
        {
            var converter = new MyDataConverter(stream);
            // do work here...
        }
    }
