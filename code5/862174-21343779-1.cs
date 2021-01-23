    private DataClass ModifySerialized(ref DataClass target)
    {
        MemoryStream stream = new MemoryStream();
        DataContractSerializer serializer = new DataContractSerializer(typeof(DataClass));
        serializer.WriteObject(stream, new DataClass() { Name = "serialized", Number = 777 });
        stream.Seek(0, SeekOrigin.Begin);
        string sDebug = ASCIIEncoding.ASCII.GetString(stream.GetBuffer());
        Console.WriteLine(sDebug);
        target = (DataClass)serializer.ReadObject(stream);
        Console.WriteLine(target);
    }
    public Test()
    {
        DataClass testDataClass = new DataClass() { Name = "Foo", Number = 123 };
        ModifySerialized(ref testDataClass);
        Console.WriteLine(testDataClass);
    }
