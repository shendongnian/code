    public static string Serialize<T>(this T value)
    {
        if (value == null) { return string.Empty; }
        try
        {
            var xmlserializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, value);
                return stringWriter.ToString();
            }
        }
        catch (Exception e)
        {
            throw new Exception("An Error Occurred", e);
        }
    }
