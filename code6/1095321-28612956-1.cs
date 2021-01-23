    private void richTextBoxGuess _TextChanged(object sender, EventArgs e)
    {
        if (richTextBoxGuess .Text.Length <= 0) return;
        string s = richTextBoxGuess.Text.Substring(0, 1);
        if (s != s.ToUpper())
        {
            int curSelStart = richTextBoxGuess.SelectionStart;
            int curSelLength = richTextBoxGuess.SelectionLength;
            richTextBoxGuess.SelectionStart = 0;
            richTextBoxGuess.SelectionLength = 1;
            richTextBoxGuess.SelectedText = s.ToUpper();
            richTextBoxGuess.SelectionStart = curSelStart;
            richTextBoxGuess.SelectionLength = curSelLength;
        }
    }
