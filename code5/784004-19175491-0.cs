    public T Deserialise<T>(string xml) where T : class
    {
        T foo;
        try
        {
            var serializer = new XmlSerializer(typeof(T));
            foo = (T)serializer.Deserialize(new XmlTextReader(new System.IO.StringReader(xml)));
        }
        catch(Exception ex)
        {
            Console.WriteLine("Failed to Deserialise " + xml + " " + ex);
            throw;
        }
        return foo;
    }
