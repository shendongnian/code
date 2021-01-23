    // get repeated items
    var repeated = localTextEntries.GroupBy(t => t.Id).Where(g => g.Count() > 1).Select(i => i);
    // get not repeated items
    var notRepeated = localTextEntries.GroupBy(t => t.Id).Where(g => g.Count() == 1).Select(i => i.First());
    // find not repeated items and create a dictionary
    var dictFromNotRepeated = localTextEntries.GroupBy(t => t.Id)
                .Where(g => g.Count() == 1)
                .ToDictionary(g => g.Key, g => g.First());
