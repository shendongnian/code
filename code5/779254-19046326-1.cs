    public object Convert(
        object value, Type targetType, object parameter, CultureInfo culture)
    {
        var returnText = value as string;
        if (!string.IsNullOrEmpty(returnText))
        {
            var keywords = new string[]
            {
                "test1",
                "test2",
                "test3",
            };
            var replacements = new string[]
            {
                "<FONT style=\"BACKGROUND-COLOR: Blue\">$1</FONT>",
                "<FONT style=\"BACKGROUND-COLOR: Beige\">$1</FONT>",
                "<FONT style=\"BACKGROUND-COLOR: Azure\">$1</FONT>"
            };
            for (int i = 0; i < keywords.Length; i++)
            {
                var replacePattern = @"(?![^<>]*>)(" + keywords[i] + ")";
                returnText = Regex.Replace(returnText,
                                           replacePattern,
                                           replacements[i],
                                           RegexOptions.IgnoreCase);
            }
        }
        return returnText;
    }
