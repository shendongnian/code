    string[] textBoxLines = richTextBox1.Lines;
    for (int i = 0; i < textBoxLines.Length; i++)
    {
        string line = textBoxLines[i];
        if (line.StartsWith("-->"))
        {
            richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(i);
            richTextBox1.SelectionLength = line.Length;
            richTextBox1.SelectionFont = yourFont;
        }
    }
    richTextBox1.SelectionLength = 0;//Unselect the selection
