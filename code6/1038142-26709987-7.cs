    public static string GetFolderByLevel(this string path, string baseFolderPath, int level)
    {
        if (path == null)
            throw new ArgumentNullException("path");
        if (baseFolderPath == null)
            throw new ArgumentNullException("baseFolderName");
        var pathFolders = path.Split(new char[] {Path.DirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries);
        var basePathFolders = baseFolderPath.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
        int baseFolderIndex = -1;
        int folderCounter = 0;
        for (int i = 0; i < pathFolders.Length; ++i)
        {
            if (string.Compare(pathFolders[i], basePathFolders[folderCounter], true) == 0)
            {
                if (++folderCounter == basePathFolders.Length)
                {
                    baseFolderIndex = i;
                    break;
                }
            }
            else
            {
                folderCounter = 0;
            }
        }
        if (baseFolderIndex < 0)
           throw new ArgumentException(string.Format("Folder '{0}' could not be found in specified path: {1}", baseFolderPath, path), "baseFolderName");
        int index = baseFolderIndex + level;
        if (-1 < index && index < pathFolders.Length)
        {
            return pathFolders[index];
        }
        else
            throw new ArgumentOutOfRangeException(string.Format("Specified level is out of range."));
    }
