    var text = File.ReadAllText("filename.txt");
    var lines = text.Split('^');
    foreach (var csv in lines
          .Select(line => line.Split(new string[] {Environment.NewLine}, 
             StringSplitOptions.None))
             .Select(sublines => string.Join(",", sublines.Select(s => s.ToString()))))
    {
        File.AppendText("NewFile.txt").WriteLine(csv);
    }
