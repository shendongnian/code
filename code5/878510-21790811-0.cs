    string excludeSubFolders = "SubFolderA, SubFolderB, SubFolderC, SubFolderABC";
    string[] excludeSubArray = excludeSubFolders.Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries);
    foreach (DirectoryInfo folder in directories.Where(dir => !excludeSubArray.Contains(dir.Name.ToString().Trim())))
    {
        // ...
    }
