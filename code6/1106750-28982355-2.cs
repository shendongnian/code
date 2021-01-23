    public static void Main(string[] args)
    {
        var myObjectToSerialize = new Root()
        {
            Child1 = 1,
            Child2 = 2,
            Child3 = 3
        };
        var serializer = new XmlSerializer(typeof(Root));
        serializer.Serialize(Console.Out, myObjectToSerialize);
        Console.ReadKey();
    }
