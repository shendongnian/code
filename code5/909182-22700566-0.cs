    public bool FindAndSelect(string TextToFind, bool MatchCase)
    {
         var mode = MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
         int position = textBox.Text.IndexOf(TextToFind, mode);
         if (position == -1)
             return false;
         textBox.SelectionStart = position;
         textBox.SelectionLength = TextToFind.Length;
         return true;
    }
