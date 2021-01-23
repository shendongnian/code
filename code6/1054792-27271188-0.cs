    static void Main()
    {
        RootObject obj = new RootObject
        {
            Services = new Services
            {
                TileMapService = new Service
                {
                    Title = "abc",
                    href = "def"
                }
            }
        };
        WriteToXmlFile("foo.xml", obj);
        var loaded = Deserialize<RootObject>("foo.xml");
        var svc = loaded.Services.TileMapService;
        System.Console.WriteLine(svc.Title); // abc
        System.Console.WriteLine(svc.href); // def
    }
    public static void WriteToXmlFile<T>(string filePath, T objectToWrite)
    {       
        var serializer = new XmlSerializer(typeof(T));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, objectToWrite);
        }
    }
    public static T Deserialize<T>(string filePath)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (var reader = new StreamReader(filePath))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
