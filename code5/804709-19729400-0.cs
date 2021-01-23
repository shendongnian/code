    public static void MyWriteAllLines(string filename, IEnumerable<string> lines)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var line in lines)
                writer.WriteLine(line);
        }
    }
