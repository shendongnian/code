    public static List<String> GetAllFiles(string pattern, IsolatedStorageFile storeFile)
    {
        // Get the root and file portions of the search string. 
        string fileString = Path.GetFileName(pattern);
        List<String> fileList = new List<String>(storeFile.GetFileNames(pattern));
        // Loop through the subdirectories, collect matches, 
        // and make separators consistent. 
        foreach (string directory in GetAllDirectories("*", storeFile))
        {
            foreach (string file in storeFile.GetFileNames(directory + "/" + fileString))
            {
                fileList.Add((directory + "/" + file));
            }
        }
        return fileList;
    }
