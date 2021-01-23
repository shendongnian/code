    var result = new StringBuilder();
    foreach (var line in File.ReadAllLines(filename))
    {
        result.AppendLine(Regex.Replace(line, @"\s", "")));
    }
    textBox1.Text = result.ToString();
