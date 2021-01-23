    var filePath = @"C:\Temp\temp.txt";
    TextReader reader = new StreamReader(filePath);
    var sentences = new StringBuilder();
    while (reader.Peek() >= 0)
    {
        var line = reader.ReadLine();
        if (line.Trim().EndsWith("."))
        {
            line
                .Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(l => sentences.AppendLine(l.Trim() + "."));
        }
    }
    Console.WriteLine(sentences.ToString());
