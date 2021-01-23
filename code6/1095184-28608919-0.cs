    static void Main(string[] args)
    {
        List<string[]> values= new List<string[]>();
    
        var reader = new StreamReader(File.OpenRead(@"C:\path"));
        while (!reader.EndOfStream)
        {
    
            string line = reader.ReadLine();
            values.Add(line.Split(';'));
        }
    }
