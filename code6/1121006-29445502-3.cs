    void changeLine(RichTextBox RTB, int line, string text)
    {
        int s1 = RTB.GetFirstCharIndexFromLine(line);
        int s2 = line < RTB.Lines.Count() - 1 ?
                  RTB.GetFirstCharIndexFromLine(line+1) - 1 : 
                  RTB.Text.Length;        
        RTB.Select(s1, s2 - s1);
        RTB.SelectedText = text;
    }
