    static void Main(string[] args)
    {
        if (args.Length > 0 && File.Exists(args[0]))
        {
            string path = args[0];
            using (StreamReader sr = new StreamReader(path))
            {
               // do something with the file
            }
        }
    }
