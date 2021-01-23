    var list = new ListWithDuplicates();
    var pairs = data.Split(new[] {"\",\""}, StringSplitOptions.None);
    foreach (var pair in pairs)
    {
        list.AddRange(pair.Split(new[] {"\":\""}, StringSplitOptions.None));
    }
