    private static void ReadIntFromFile(string filename)
    {
        string firstLine = System.IO.File.ReadLines(filename).First();
    
        Interlocked.Add(ref result, int.Parse(firstLine));
    }
