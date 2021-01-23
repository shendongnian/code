    for (int i = 0; i < length; i++) 
    {
        string newText = row.Cells[i].Text.ToString(); 
        if (newText.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0
        {
            string highlight = "<span style='background-color:yellow'>$0</span>";
            string replacedText = Regex.Replace(newText, text, highlight, RegexOptions.IgnoreCase);
            row.Cells[i].Text = replacedText;
        }
    }
