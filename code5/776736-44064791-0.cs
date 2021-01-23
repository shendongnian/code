    void CopyAction(object sender, EventArgs e)
    {
        if (richTextBox1.SelectedText != null && richTextBox1.SelectedText != "")
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }
    }
    void PasteAction(object sender, EventArgs e)
    {
        if (Clipboard.ContainsText())
        {
            int selstart = richTextBox1.SelectionStart;
            if (richTextBox1.SelectedText != null && richTextBox1.SelectedText != "")
            {
                richTextBox1.Text = richTextBox1.Text.Remove(selstart, richTextBox1.SelectionLength);
            }
    
            string clip = Clipboard.GetText(TextDataFormat.Text).ToString();
            richTextBox1.Text = richTextBox1.Text.Insert(selstart, clip);
            richTextBox1.SelectionStart = selstart + clip.Length;
        }
    }
