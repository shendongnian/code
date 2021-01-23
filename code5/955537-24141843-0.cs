    var result = new Dictionary<string, string[]>();
    var input = File.ReadAllLines(@"c:\temp\test.txt");
    var currentValue = new List<string>();
    var currentKey = string.Empty;
    foreach (var line in input)
    {
        if (currentKey == string.Empty)
        {
            currentKey = line;
        }
        else if (!string.IsNullOrEmpty(line))
        {
            currentValue.Add(line);
        }
        if (string.IsNullOrEmpty(line))
        {
            result.Add(currentKey, currentValue.ToArray());
            currentKey = string.Empty;
            currentValue = new List<string>();
        }
    }
    if (currentKey != string.Empty)
    {
        result.Add(currentKey, currentValue.ToArray());
    }
