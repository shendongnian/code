    private FormattedText getLongestFormattedString(IEnumerable<string> list, Typeface typeface, double size)
    {
        FormattedText longest = null;
                
        foreach(string item in list)
        {
            var renderedText = new FormattedText(filter.Filter.Name,
                                   System.Globalization.CultureInfo.CurrentCulture,
                                   FlowDirection.LeftToRight, typeface,
                                   size, Brushes.Black);
            longest = (longest == null || renderedText.WidthIncludingTrailingWhitespace > longest.WidthIncludingTrailingWhitespace) ? renderedText : longest;
        }
        return longest;
    }
