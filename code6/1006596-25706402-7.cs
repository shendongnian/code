    var csv = string.Join(Environment.NewLine, text.Split(new []{Environment.NewLine+"^", "\n^"}, StringSplitOptions.None)
      	.Select(line => line.Split(new []{Environment.NewLine, "\n"}, StringSplitOptions.None))
        .Select(sublines => string.Join(",", sublines.Select(s => s.ToString()))));
    using(var file = File.AppendText("NewFile.txt"))
        file.WriteLine(csv);
