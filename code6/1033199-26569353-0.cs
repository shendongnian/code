    static void Main(string[] args)
    {
        if ((args.Length > 0) && System.IO.File.Exists(args[0]))
        {
            System.Diagnostics.Debug.WriteLine("File path to open: ");
            string filepath = args[0];
        }
    }     
