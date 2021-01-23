    public static string RemoveBadChars(string word)
    {
        Regex reg = new Regex("[^a-zA-Z']");
        return reg.Replace(word, string.Empty);
    }
