    if (e.KeyChar == (char)Keys.Enter)
    {
        richTextBox1.AppendText(Environment.NewLine);
        int prevLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) - 1;
        MatchCollection mc = Regex.Matches(richTextBox2.Lines[prevLine], "\s+");
        if (mc.Count > 0)
            richTextBox1.AppendText(mc[0].Value);
        e.Handled = true;
    }
