    string stringData = "[\"on4ThnU7\", \"n71YZYVKD\", \"CVfSpM2W\", \"10kQotV\"]";
    string[] arrayData;
    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(stringData)))
    {
        var deserializer = new DataContractJsonSerializer(typeof(string[]));
        arrayData = deserializer.ReadObject(ms) as string[];
    }
    if (arrayData == null) 
        Console.WriteLine("Wrong data");
    else
    {
        foreach (var item in arrayData) 
            Console.WriteLine(item);
    }
