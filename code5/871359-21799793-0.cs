    private static IList<string> ExtractWords(DocX doc)
    {
        // Get all the text without the headlines
        var text = doc.Text;
        // Maybe you want to tweak this and more items or use a different approach,
        // e.g. using Regex like proposed by @Omri Aharon
        var separators = "\r\n\"”“„?«» .!?,{}[]-".ToCharArray();
        var strings = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        return strings.ToList();
    }
