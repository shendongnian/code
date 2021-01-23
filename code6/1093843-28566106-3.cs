    static void Main(string[] args)
    {
        List<string> list = new List<string> {"One", "Two", "Three", "Four", "Five" };
        string text = "OneTwoThreeFourFive";
        string withSpaces = AddSpacesToSentence(text, true);
        List<string> list2 = withSpaces.Split(' ').ToList();
        bool b = list.SequenceEqual(list2);
    }
    // Refer to: http://stackoverflow.com/a/272929/4551527
    static string AddSpacesToSentence(string text, bool preserveAcronyms)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;
        StringBuilder newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]))
                if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                    (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                        i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                    newText.Append(' ');
            newText.Append(text[i]);
        }
        return newText.ToString();
    }
