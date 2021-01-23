    static void Main(string[] args)
    {
        IEnumerable<string> files = Directory.EnumerateFiles(@"C:\", "*.*",
                                SearchOption.AllDirectories);
        foreach (string file in files)  // Exception occurs when evaluating "file"
        {
            try
            {
                Console.WriteLine(file);
            }
            Catch(Exception ex)
            {
            }
        }
    }
