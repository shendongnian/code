    //reuse the same rtfBox object over instead of creating/disposing a new one each time ToPlainText is called
    static ThreadLocal<RichTextBox> rtfBox = new ThreadLocal<RichTextBox>(() => new RichTextBox());
    public static string ToPlainText(this string sourceString)
    {
        if (sourceString == null)
            return null;
        rtfBox.Value.Rtf = sourceString;
        var strippedText = rtfBox.Value.Text;
        rtfBox.Value.Clear();
        return strippedText;
    }
