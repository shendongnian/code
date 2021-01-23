    // Check in which paragraph TablesOfFigures[1] is found
    for (int i=1; i <= wordApp.ActiveDocument.Paragraphs.Count; i++)
    {
        if (IsInRange(wordApp.ActiveDocument.TablesOfFigures[1].Range, wordApp.ActiveDocument.Paragraphs[i].Range))
        {
            MessageBox.Show("ToF is in paragraph " + i);
        }
    
    }
    // Returns true if 'target' is contained in 'source'
    private bool IsInRange(Range target, Range source)
    {
        return target.Start >= source.Start && target.End <= source.End;
    }
