    private static List<string> ReadFile(string FileName)
    {
        if (!File.Exists(FileName))
        {
            Console.WriteLine("File not found");
            return null;
        }
        var lines = File.ReadAllLines(FileName);
        return lines.ToList();
    }
