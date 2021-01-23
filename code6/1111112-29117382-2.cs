    bool inTextChanged = false;
    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (inTextChanged)
            return;
        TextBox txt = (TextBox)sender;
        string[] lines = ((TextBox)sender).Lines;
        if (lines.Length != 0)
        {
            string[] newLines = File.ReadLines("Path")
                .Select((line, index) =>
                {
                    if (!line.StartsWith("set ", StringComparison.InvariantCultureIgnoreCase)
                        || !line.Contains('=')
                        || index < lines.Length)
                        return line;
                    return string.Format("set {0}={1}",
                        line.Split(' ')[1].Split('=')[0].Trim(),
                        lines[index]);
                }).ToArray();
            txt.Lines = newLines;
            inTextChanged = false;
        }
    }
