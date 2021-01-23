    // need to use String.Join to get something that is comparable easily
    IEnumerable<string> first = table1.AsEnumerable()
        .Select(r => string.Join(",",r.ItemArray));
    IEnumerable<string> second = table2.AsEnumerable()
        .Select(r => string.Join(",", r.ItemArray));
    int index = second.IndexOfSequence(first, null);  // 1
