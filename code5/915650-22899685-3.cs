    var lines = File.ReadLines("path")
                    .Where(x => !x.StartsWith("name1 or whatever"));
    var newLines = lines.Concat(new [] { line });
    
    File.WriteAllLines("path", newLines);
