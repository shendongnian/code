    List<string> strings = new List<string>() {"Zero", "One", "Two", "Three", "Four", "Five"};
    var stringsArr = strings.ToArray();
    var indices    = Enumerable.Range(0, strings.Count).ToArray();
    Array.Sort(stringsArr, indices);
    for (int i = 0; i < stringsArr.Length; ++i)
        Console.WriteLine("{0} has original index {1}", stringsArr[i], indices[i]);
    // Add stringsArr to the listbox.
    // If an index from the listbox is lbi, then the original index of the item
    // that it refers to will be indices[lbi]
