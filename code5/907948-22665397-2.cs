    string[] lines = File.ReadAllLines(textBox7.Text);
    List<string> result = new List<string>();
    foreach(string line in lines)
    {
        result.AddRange(GetMatchingLines(lines, textBox9.Text, 2, 2));
        result.AddRange(GetMatchingLines(lines, textBox10.Text, 2, 2));
    }
    File.WriteAllLines(textBox8.Text, result);
