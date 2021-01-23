    public static void Save(string FileName, object o)
    {
        using (var writer = new System.IO.StreamWriter(FileName))
        {
            var serializer = new XmlSerializer(o.GetType());
            serializer.Serialize(writer, o);
            writer.Flush();
        }
    }
    public static object Load(string FileName, Type t)
    {
        using (var stream = System.IO.File.OpenRead(FileName))
        {
            var serializer = new XmlSerializer(t);
            return serializer.Deserialize(stream);
        }
    }
