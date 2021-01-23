    public static void AppendAllLines(string path, IEnumerable<string> lines)
    {
        using (var writer = new StreamWriter(path, true))
            foreach (var line in lines)
                writer.WriteLine(line);
    }
