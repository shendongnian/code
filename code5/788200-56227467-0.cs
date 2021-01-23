    public static T ParseXml<T>(this string @this) where T : class
    {
        var serializer = new XmlSerializer(typeof(T));
        serializer.UnknownElement += Serializer_UnknownElement;
        return serializer.Deserialize(new StringReader(@this)) as T;            
    }
