    private void HighlightLine(int lineIdx)
    {
        richTextBox1.Select(richTextBox1.GetFirstCharIndexFromLine(lineIdx), richTextBox1.Lines[lineIdx].Length);
        richTextBox1.SelectionColor = Color.Red;
    }
