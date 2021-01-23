    /// <summary>
    /// Creates a deep clone of an object using serialization.
    /// </summary>
    /// <typeparam name="T">The type to be cloned/copied.</typeparam>
    /// <param name="o">The object to be cloned.</param>
    public static T DeepClone<T>(this T o)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }
    }
