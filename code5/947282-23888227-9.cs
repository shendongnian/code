    public IEnumerable<string> SplitCSV(string input)
    {
        Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
    
        foreach (Match match in csvSplit.Matches(input))
        {
            yield return match.Value.TrimStart(',');
        }
    }
    string s = "3,\"dac\",\"fsdf,sdf\",\"DdsA 102-13\",62.560000000000002,\"1397\",\"bes\",\"165/70/R13\",945,1380,\"Break\",10";
    var words = SplitCSV(s);
    foreach (string word in words)
    {
        Console.WriteLine(word); 
    }
