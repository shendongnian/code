    public List<string> GetXMLFilesRecursive(string currentFolder)
    {
        List<string> results = new List<string>();
        // Enumerate all directories of currentFolder
        string[] folders = Directory.GetDirectories(currentFolder);
        foreach (string folder in folders)
            results.AddRange(GetXMLFilesRecursive(folder));
        // Enumerate all XML files in this folder only if it has no other sub-folders (is a leaf)
        if (folders.Length == 0)
        {
            string[] xmlFiles = Directory.GetFiles(currentFolder, "*.xml");
            results.AddRange(xmlFiles);
        }
        return results;
    }
