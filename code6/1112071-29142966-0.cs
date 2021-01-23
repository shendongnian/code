    var lst1 = new string[] {"Folder1\\File.png", "Folder1\\File2.png" , "File3.png", "File4.png" };
    var grps = lst1.GroupBy(x => x.Contains(@"\"));
    foreach (var g in grps)
    {
        if (g.Key) // we have a path with directory
            Console.WriteLine(String.Join("\r\n", g.ToList()));
        else // we have an individual file
             Console.WriteLine(String.Join("\r\n", g.ToList()));
    }
