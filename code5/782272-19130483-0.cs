    static void targetMethod(object obj)
    {
        Tuple<string, int> tuple = (Tuple<string, int>)obj;
        Console.WriteLine(tuple.Item1);
        Console.WriteLine(tuple.Item2);
    }
    static void Main(string[] args)
    {
        Thread thread = new Thread(targetMethod);
        thread.Start(new Tuple<string, int>("simple string", 123));
        thread.Join();
        Console.ReadLine();
    }
