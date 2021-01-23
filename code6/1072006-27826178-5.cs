    public IEnumerable<object> ParseInput(string input)
    {
        return Regex.Matches(input.Replace(" ", string.Empty), @"(?<A>\d+(\.\d+)?)(-(?<B>\d+(\.\d+)?))?").Cast<Match>()
            .Select(m => new
            { 
                A = m.Groups["A"].Value,  
                B = m.Groups["B"].Value
            });
    }
