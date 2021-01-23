    private string getText(Control parent)
    {
        string output = string.Empty;
        List<TextBox> lTB = new List<TextBox>();
        foreach (Control aktControl in parent.Controls)
        { if (aktControl is TextBox) lTB.Add((aktControl as TextBox)); }
        lTB = lTB.OrderBy(tb => tb.Name).ToList();
        foreach (TextBox aktTextBox in lTB)
        { output += aktTextBox.Text; }
        return output;
    }
