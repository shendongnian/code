    private static int ReadIntFromFile(string filename)
    {
        string firstLine = System.IO.File.ReadLines(filename).First();
        return int.Parse(firstLine);
    }
