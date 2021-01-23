    var line = File.ReadLines("path")
                   .FirstOrDefault(x => x.StartsWith(username));
    if (line != null)
    {
         line = newValue; // change the line
         File.WriteAllLines("path", File.ReadLines("path")
             .Where(x => !x.StartsWith(username)).Concat(new[] {line});
    }
