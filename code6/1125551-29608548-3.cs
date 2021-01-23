    string getWordAtIndex(RichTextBox RTB, int index)
    {
        string wordSeparators = " .,;-!?\r\n\"";
        int cp0 = index;
        int cp2 = RTB.Find(wordSeparators.ToCharArray(), index);
        for (int c = index; c > 0; c--)
        { if (wordSeparators.Contains(RTB.Text[c])) { cp0 = c + 1; break; } }
        int l = cp2 - cp0;
        if (l > 0) return RTB.Text.Substring(cp0, l); else return "";
    }
