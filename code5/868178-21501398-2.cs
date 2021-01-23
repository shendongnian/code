    public static void Save(string filepath, Foo foobject)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Foo));
        using (Stream stream = File.OpenWrite(filepath))
        {
            serializer.Serialize(stream, foobject);
        }
    }
    public static Foo Load(string filepath)
    {
        Foo myFoo;
        XmlSerializer serializer = new XmlSerializer(typeof(Foo));
        using (Stream stream = File.OpenRead(filepath))
        {
            myFoo = (Foo)serializer.Deserialize(stream);
        }
    }
