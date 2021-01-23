    // We group by size, and we take only the groups that have multiple files
    var grouped = fileList.GroupBy(x => x.Length).Where(x => x.Count() > 1);
    // Each group is "keyed"/"grouped" by size
    foreach (var group in grouped)
    {
        Console.WriteLine("Size: {0}", group.Key);
        foreach (var file in group)
        {
            Console.WriteLine(" {0}", file.FullName);
        }
    }
