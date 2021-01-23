    int count = 0;
    foreach (string line in File.ReadLines(@"C:\Exercises\gamenam.dat"))
    {
        if (line.StartsWith("02"))
            count++;
        Match clientMatch = Regex.Match(line, @"(?<=\(End of client )\d+(?=\))");
        if (clientMatch.Success)
        {
            // Replace line below with write to output file
            Console.WriteLine("Client {0} has {1} occurrences of \"02\".", 
                              clientMatch.Value, count);
            count = 0;
        }
    }
