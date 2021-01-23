    public T ToObject<T>(this XNode node)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = node.CreateReader())
        {
            return (T)serializer.Deserialize(reader);
        }
    }
