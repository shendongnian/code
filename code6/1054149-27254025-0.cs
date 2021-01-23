    private void tb_TextChanged(object sender, RoutedEventArgs e)
    {
        // we don't want this handler being called as a result of
        // formatting changes being made here
        tb.TextChanged -= tb_TextChanged;
    
        var doc = tb.Document;
        doc.BatchDisplayUpdates();
    
        try
        {
            string text;
            doc.GetText(TextGetOptions.None, out text);
            if (text.Length == 0)
                return;
    
            // check if this word starts with a hash
            var start = doc.Selection.StartPosition - 1;
            while (true)
            {
                if (start < 0 || char.IsWhiteSpace(text[start]))
                    return;
                if (text[start] == '#')
                    break;
                start--;
            }
    
            // find the end of the word
            var end = doc.Selection.StartPosition;
            while (start < text.Length && !char.IsWhiteSpace(text[end]))
                end++;
    
            // set color
            doc.GetRange(start, end).CharacterFormat.ForegroundColor = Colors.RoyalBlue;
        }
        finally
        {
            doc.ApplyDisplayUpdates();
            tb.TextChanged += tb_TextChanged;
        }
    }
