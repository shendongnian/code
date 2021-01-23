    var allEntriesFound = EnumerateFindFileSystemEntries("PresentationFramework.dll").ToList();
    if(allEntriesFound.Any())
    {
        foreach (FileEntryInfo entry in allEntriesFound)
            Console.WriteLine("{0}: Number: {1}", entry.Path, entry.Number);
        // here your exact requirement:
        string result = string.Join(".", allEntriesFound[0].GetNumberTree());
        Console.WriteLine(result);
    }
