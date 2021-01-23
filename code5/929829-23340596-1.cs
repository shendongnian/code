    public static T Deserialize<T>(string xml)
    {
        try
        {
            var serializer = new XmlSerializer(typeof (T));
            using (var sr = new StreamReader(xml))
            using (var reader = XmlReader.Create(sr))
                return (T) serializer.Deserialize(reader);
        }
        catch (Exception)
        {
            // clean up if needed 
            throw; // throw and keep stack trace
        }
