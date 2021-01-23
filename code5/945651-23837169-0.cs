    string[] options = { "15", "12", "52", "a", "12", "15", "abc", "15" };
    var groupedOptions = options.GroupBy(o => o)
                                .ToDictionary(g => g.Key, g => g.Count());
    foreach (var groupedOption in groupedOptions)
        Console.WriteLine("{0} : {1}", groupedOption.Key, groupedOption.Value);
