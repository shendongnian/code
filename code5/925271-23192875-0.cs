    public string MatchedName(string input)
    {
        const int nameColumnIndex = 0;
        const string matchFile = @"C:\matchedfile.txt";
    
        string normalizedInput = RemoveCharTab(input);
    
        string[] names = File.ReadAllLines(matchFile)
                             .Select(l => l.Split(',')[nameColumnIndex])
                             .Select(s => s.Trim())
                             .ToArray();
        return names.FirstOrDefault(n => string.Equals(RemoveCharTab(n), normalizedInput)) ?? input;
    }
