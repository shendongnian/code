    private void PrintBox(char c, int width, int height)
    {
        var result = new List<string>();
        result.Add(Repeat(c, width)); // First line
        for (var i = 0; i < height - 2; i++)
        {
            string iLine;
            int spaceCount = width - 2;
            iLine = Repeat(c, 1) + Repeat(' ', spaceCount) + Repeat(c, 1);
            result.Add(iLine);
        }
        result.Add(Repeat(c, width)); // Last line
        // FYI, there's a StringBuilder class that makes all this easier
        foreach (var line in result)
        {
            Console.WriteLine(line);
        }
    }        
    private string Repeat(char c, int count)
    {
        // Construct the sequence
    }
