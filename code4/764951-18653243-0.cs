    var dirFileCount = directory.EnumerateFiles("*.pdf", SearchOption.AllDirectories).Count();
    dirFileCount += directory.EnumerateFiles("*.xls", SearchOption.AllDirectories).Count();
    dirFileCount += directory.EnumerateFiles("*.doc", SearchOption.AllDirectories).Count();
    dirFileCount += directory.EnumerateFiles("*.xlsx", SearchOption.AllDirectories).Count();
    dirFileCount += directory.EnumerateFiles("*.docx", SearchOption.AllDirectories).Count();
    dirFileCount += directory.EnumerateFiles("~*", SearchOption.AllDirectories).Count();
    if (dirFileCount != 0)
        directoryNode.Nodes.Add(CreateDirectoryNode(directory));
