    var dictionary = new Dictionary<string, string>();
    for (int index = 0; index < list.Count; index += 2)
    {
        dictionary[list[index]] = list[index + 1];
    }
