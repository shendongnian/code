    static int Main(string[] args)
    {
        if (args.Length != 2) 
        {
            Console.Error.WriteLine("This program requires exactly 2 parameters");
            return 1; // error code
        }
        string input = args[0];
        string output = args[1];
        GeneratePDF.GeneratePDF_Ctaf(input, output);
        return 0; // no error
    }
