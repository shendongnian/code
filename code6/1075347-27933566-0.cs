    var MappingDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
    MappingDictionary.Add("1", "a");
    MappingDictionary.Add("2", "q");
    var name = Console.ReadLine();
    if (!string.IsNullOrEmpty(name))
    {
        var s = new StringBuilder(500);
        foreach (var sourceChar in name)
        {
            string mappedTo;
            if (MappingDictionary.TryGetValue(sourceChar.ToString(), out mappedTo))
            {
                s.Append(mappedTo);
            }
        }
    }
