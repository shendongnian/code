    var line = File.ReadLines("path")
                   .FirstOrDefault(x => x.StartsWith(username));
    if (line != null)
    {
         var parts = line.Split(',');
         parts[1] = "1500"; // new number
         line = string.Join(",", parts);
         File.WriteAllLines("path", File.ReadLines("path")
             .Where(x => !x.StartsWith(username)).Concat(new[] {line});
    }
