    private static void FindRegExMatches(string pattern)
    {
        for (var i = 0; i < 1000; i++)
        {
            var numberString = i.ToString().PadLeft(3, '0');
            if (!Regex.IsMatch(numberString, pattern)) continue;
            
            Console.WriteLine("Found a match: {0}, numberString);
        }
    }
