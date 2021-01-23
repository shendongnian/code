    public static void WriteMessage<T>(T objectA) where T : SuperClass
    {
        var text = objectA.MethodOne();
        Console.WriteLine("Text:{0}", text);
    }
