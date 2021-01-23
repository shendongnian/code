    string[] lines = File.ReadAllLines(textBox7.Text);
    List<string> result = new List<string>();
    if (!string.IsNullOrEmpty(textBox9.Text))
    {
        result.AddRange(GetMatchingLines(lines.ToList(), textBox9.Text, 2, 2));
    }
    if (!string.IsNullOrEmpty(textBox10.Text))
    {
        result.AddRange(GetMatchingLines(lines.ToList(), textBox10.Text, 2, 2));
    }
    File.WriteAllLines(textBox8.Text, result);
