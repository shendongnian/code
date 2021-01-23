    public static KeyValuePair<string,string> SplitToKeyValue(string text) {
        Regex p = new Regex(@"^(\w+)\s+(.*)$");
        Match m = p.Match(text);
        return new KeyValuePair<string,string>(m.Groups[1].Value,m.Groups[2].Value);
    }
