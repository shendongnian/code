    private static Regex badChars = new Regex("[^A-Za-z']");
    public static string RemoveBadChars(string word)
    {
        return badChars.Replace(word, "");
    }
