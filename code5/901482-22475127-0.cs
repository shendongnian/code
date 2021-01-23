    string text = File.ReadAllText(FileName, Encoding.Default);
    string[] fields = text.Split('|');
    IEnumerable<string[]> lines = fields
        .Select((f, i) => new { Field = f, Index = i })
        .GroupBy(x => x.Index / 8)
        .Select(g => g.Select(x => x.Field).ToArray());
    foreach(string[] lineFields in lines)
        Console.WriteLine(string.Join(", ", lineFields));
