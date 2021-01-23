    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up )
        {
            int selectionStart = richTextBox1.SelectionStart;
            int lineIndex = richTextBox1.GetLineFromCharIndex(selectionStart);
            label1.Text = lineIndex.ToString();
        }
    }
