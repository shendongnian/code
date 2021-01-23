    static void Main(string[] args)
    {
        string[] testStrings = { "DJ Doena", "äöüßéèâ", "< ä ß á â & 木 >" };
        foreach (string text in testStrings)
        {
            Console.WriteLine(ReencodeText(text));
        }
    }
    private static string ReencodeText(string text)
    {
        Encoding encoding = Encoding.GetEncoding(1252);
        string text1252 = encoding.GetString(encoding.GetBytes(text));
        return text.Equals(text1252, StringComparison.Ordinal) ?
            text : Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }
