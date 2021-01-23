    public static T GetObjectInformationFromFile<T>(string passedDestinationFileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using(var stream = new StreamReader(passedDestinationFileName))
        {
            return (T)serializer.Deserialize(stream);
        }
    }
