    static Dictionary<string, string> charMap = new Dictionary<string, string>()
    {
       {"alpha", "a"},{"beta","Y"},{"gamma", "g"},{"delta", "="}
    };
    static string CharMap(string value)
    {
        return Regex.Replace(value, @"(\w+)\s*", m => {
            string result;
            charMap.TryGetValue(m.Groups[1].Value, out result);
            return result ?? m.Groups[1].Value;
        });
    }
    Console.WriteLine(CharMap("alpha beta gamma delta")); // aYg=
