    // I've used String.Join to get something that is comparable easily
    // from the ItemArray that is the object-array of all fields
    IEnumerable<string> first = table1.AsEnumerable()
        .Select(r => string.Join(",",r.ItemArray));  // 
    IEnumerable<string> second = table2.AsEnumerable()
        .Select(r => string.Join(",", r.ItemArray));
    int index = second.IndexOfSequence(first, null);  // 1
