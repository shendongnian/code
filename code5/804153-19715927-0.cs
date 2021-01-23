    public static void AppendAllLines(string path, IEnumerable<string> lines)
    {
        using (var writer = new StreamWriter(File.OpenWrite(path)))
            foreach (var line in lines)
                writer.WriteLine(line);
    }
