    var lines = richTextBox1.Lines;
    for (int i = lines.Count()-1;i>=0; i--)
    {
        if (lines[i].StartsWith("#"))
        {
            var thisLineStart = richTextBox1.GetFirstCharIndexFromLine(i);
            var maxLines = richTextBox1.Lines.Count();
            if (i >= maxLines)
            {
                richTextBox1.Text = richTextBox1.Text.Remove(thisLineStart);
            }
            else
            {
                var nextLineStart = richTextBox1.GetFirstCharIndexFromLine(i + 1);
                richTextBox1.Text = richTextBox1.Text.Remove(thisLineStart, nextLineStart - thisLineStart);
            }
        }
    }
