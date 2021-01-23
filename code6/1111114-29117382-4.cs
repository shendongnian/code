    private void ButtonSumbitTextboxChangesToBatch_Click(object sender, EventArgs e)
    {
        string[] lines = TextBox1.Lines;
        if (lines.Length != 0)
        {
            string[] newLines = File.ReadLines("Path")
                .Select((line, index) =>
                {
                    if (!line.StartsWith("set ", StringComparison.InvariantCultureIgnoreCase)
                        || !line.Contains('=')
                        || index >= lines.Length)
                        return line;
                    return string.Format("set {0}={1}",
                        line.Split(' ')[1].Split('=')[0].Trim(),
                        lines[index]);
                }).ToArray();
            File.WriteAllLines("Path", newLines);
        }
    }
