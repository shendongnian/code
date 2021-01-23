    public static string RemoveNoneLetterChars(string word)
    {
        Regex reg = new Regex(@"\W");
        return reg.Replace(word, " "); // or return reg.Replace(word, String.Empty); 
    }
