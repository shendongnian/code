    public static T CloneObject<T>(T object)
    {
        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, object);
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }
    }
