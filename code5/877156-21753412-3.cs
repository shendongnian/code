    public void Save(Stream stream)
    {
        YourBinaryFormatter b = new YourBinaryFormatter();
        b.Serialize(stream, this);
    }
    
