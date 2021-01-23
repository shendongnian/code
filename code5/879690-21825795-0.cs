    public string GetFilesInSameFolderAs(string filename)
    {        
        return Directory.GetFiles(Path.GetDirectoryName(filename), Path.GetExtension(filename));
    }
    foreach(string filename in GetFilesInSameFolderAs(e.FullPath))
    {
        // do something with files.
    }
