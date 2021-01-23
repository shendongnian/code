    public static void WriteFile(IEnumerable<string> lines)
    {
        // how to save the state, of observe an collection/stream???
        using(var writer = new System.IO.StreamWriter("c:\\temp\\test.txt"))
        {
            foreach(var line in lines)
                writer.WriteLine(line);
        }
    }
