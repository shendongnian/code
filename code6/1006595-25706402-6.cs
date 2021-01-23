    var text = File.ReadAllText("filename.txt");
    using(var file = File.AppendText("NewFile.txt"))
    foreach (var csv in text.Split(new []{Environment.NewLine+"^", "\n^"}, StringSplitOptions.None)
        .Select(line => line.Split(new []{Environment.NewLine, "\n"}, StringSplitOptions.None))
        .Select(sublines => string.Join(",", sublines.Select(s => s.ToString()))))
    {
        file.WriteLine(csv);
    }
