    static void Main(string[] args)
    {
        var objs = new object[] { new Class1(), new Class2() };
        // Note the change of type for item to "dynamic"
        foreach (dynamic item in objs)
        {
            Method(item);
        }
    }
