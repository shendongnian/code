    var result = new StringBuilder();
    foreach (var line in File.ReadAllLines(filename))
    {
        result.AppendLine(line
            .Replace("\t", "")
            .Replace("\n", "")
            .Replace("\r", "")
            .Replace(" ", ""));
    }
    textBox1.Text = result.ToString();
