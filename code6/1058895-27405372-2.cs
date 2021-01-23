    var entries = new HashSet<DirectoryEntry>(new DirectoryEntryEqualityComparer());
    var queue = new Queue<DirectoryEntry>();
    queue.Enqueue(startEntry);
    while (queue.Count > 0)
    {
        if (entries.Add(candidate))
        {
            foreach (var child in GetChildEntries(candidate))
            {
                queue.Enqueue(child);
            }
        }
    }
