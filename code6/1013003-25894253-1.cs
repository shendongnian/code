    List<String> foldersA = new List<string>();
    List<String> foldersB = new List<string>();
    List<String> otherFolders = new List<string>();  // Eventually 
    string rootPath = @"D:\temp";
    foreach(string s in Directory.EnumerateDirectories(rootPath, "*", SearchOption.AllDirectories))
    {
        // remove the rootPath part to apply the StartsWith check
        string temp = s.Substring(rootPath.Length + 1);
        if(s.StartsWith("folderA"))
           foldersA.Add(temp);
        else if(s.StartsWith("folderB"))
           foldersB.Add(temp);
        else
           otherFolders.Add(temp);
    }
