    private void ApplySyntaxHighlite()
    {
        string find = "using";
        if (richTextBox1.Text.Contains(find))
        {
            var matchString = Regex.Escape(find);
            foreach (Match match in Regex.Matches(richTextBox1.Text, matchString))
            {
                richTextBox1.Select(match.Index, find.Length);
                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.Select(richTextBox1.TextLength, 0);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
            };
        }
    }
