    var text = File.ReadAllText("filename.txt");
    var lines = text.Split('^');
    using(var file = File.AppendText("NewFile.txt"))
    foreach (var csv in lines
          .Select(line => line.TrimEnd(Environment.NewLine.ToCharArray())
             .Split(new string[] {Environment.NewLine}, StringSplitOptions.None))
             .Select(sublines => string.Join(",", sublines.Select(s => s.ToString()))))
    {
       file.WriteLine(csv);
    }
