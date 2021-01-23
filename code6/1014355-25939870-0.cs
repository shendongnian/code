    static void Main(string[] args)
    {
        if(args.Length > 0)
        {
            // command line passed 
            string fileToProcess = args[0];
            if(Path.GetExtension(fileToProcess) == ".abc")
            {
               // Whatever
            }
        }
    }
