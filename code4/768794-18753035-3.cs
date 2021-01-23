    class Provider { 
        public string Pattern { get; set; } 
        public string Name { get; set; } 
    }
    var providerMap =
        System.IO.File.ReadLines(@"C:\some\folder\providers.psv")
        .Select(line => line.Split('|'))
        .Select(parts => new Provider() { Pattern = parts[0], Name = parts[1] }).ToList();
