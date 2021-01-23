    public static TextFormat GetFormat(string text) {
        if (text.TrimStart().StartsWith("{\rtf", StringComparison.Ordinal))
            return TextFormat.RichText;
    
        return TextFormat.PlainText;
    }
