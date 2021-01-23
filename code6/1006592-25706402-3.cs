    var text = File.ReadAllText("filename.txt");
    using(var file = File.AppendText("NewFile.txt"))
    foreach (var csv in text.Split('^')
        .Select(line => line.TrimEnd(Environment.NewLine.ToCharArray())
        .Split(new string[] {Environment.NewLine, "\n"}, StringSplitOptions.None))
        .Select(sublines => string.Join(",", sublines.Select(s => s.ToString()))))
    {
        file.WriteLine(csv);
    }
