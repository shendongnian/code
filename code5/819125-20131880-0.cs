    public void fileContent(string fileName)
    {
        var lines = File.ReadLines(@fileName);
        foreach (string line in lines.Take(4))
        {
            richTextBox1.AppendText(line.Substring(0, 40) + Environment.NewLine);
        }
        var remaining = lines.Count() - 4;
        if (remaining > 0)
            richTextBox1.AppendText(remaining + " more line(s) are not shown.");
    }
