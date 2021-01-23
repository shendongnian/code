    var vals = File.ReadLines("C:\\TEMP\\test.ini")
        .SkipWhile(line => !line.StartsWith("[ACR]"))
        .Skip(1)
        .TakeWhile(line => !string.IsNullOrEmpty(line))
        .Select(line => new
        {
            Key = line.Substring(0, line.IndexOf(':')),
            Value = line.Substring(line.IndexOf(':') + 2)
        });
