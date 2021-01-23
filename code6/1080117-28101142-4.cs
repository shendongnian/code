    var filePath = @"C:\Temp\temp.txt";
    var sentences = new List<string>();
    using (TextReader reader = new StreamReader(filePath))
    {
        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine();
            if (line.Trim().EndsWith("."))
            {
                line
                    .Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ForEach(l => sentences.Add(l.Trim() + "."));
            }
        }
    }
    // Output sentences to console
    sentences.ForEach(Console.WriteLine);
