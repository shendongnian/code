    public static void ClearFolder(string targetDirectory, bool removeAfterwards)
    {
        // delete files in folder
        foreach (var file in Directory.GetFiles(targetDirectory))
        {
            try
            {
                File.Delete(file);
             }
             catch (IOException) 
             {
                 // file is in use, skip
             }
        }
    
        // process sub folders
        foreach (var dir in Directory.GetDirectories(targetDirectory))
            ClearFolder(dir, true);
        // delete folder itself
        if (removeAfterwards) {
            Directory.Delete(targetDirectory);
        }
    }
    ...
    ClearFolder(folderToClear, false);
