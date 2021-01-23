    public string convertToRegExp(string pattern)
    {
       string result = pattern;
       result = Regex.Replace(result, <regexp pattern matching your syntax>, <proper regexp syntax pattern>); // convert spaces to |
       result = Regex.Replace(result, <regexp pattern matching your syntax>, <proper regexp syntax pattern>); // convert ANDs
       ... // convert other rules
       return result;
    }
    public bool isConditionSatisfied(string input, string pattern)
    {
       string rePattern1 = convertToRegExp(pattern1);
       return Regex.IsMatch(input, rePattern1);
    }
