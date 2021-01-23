    public static void WriteObjectToStream(Stream outputStream, Object obj)
    {
        if (object.ReferenceEquals(null, obj))
        {
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(outputStream, obj);
    }
