    using System.Text.RegularExpressions;
    
    Regex oppNumber = new Regex(@"^Opp#: (<?number>\d)+",RegexOptions.Compiled);
    public int ParseValue(string line)
    {
        return Int32.Parse(oppNumber.Match(line).Groups["number"].Value);
    }
