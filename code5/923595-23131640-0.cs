    public static void Main(string[] args)
    {
        var path = args.Length > 0 ? args[0] : Console.ReadLine();
        Console.WriteLine(String.Format("File in folder: {0}", 
            Directory.GetFiles(path).Length));
    }
