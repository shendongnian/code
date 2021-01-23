    public static Party Load()
    {
        // ... Deserialize
        return (Party)serializer.Deserialize(stream);
    }
