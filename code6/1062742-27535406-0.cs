    string[] lines = textbox1.Text.Replace(Environment.Newline, "\n").Split('\n');
    if (lines.Count > 10)
    {
        // More than 10 lines. Show an error or something
        e.Handled = true;
        e.SuppressKeyPress = true;
        return
    }
    if (lines.Any(z => z.Length > 100))
    {
        // More then 100 character on a line. Do Something
        e.Handled = true;
        e.SuppressKeyPress = true;
        return;
    }
