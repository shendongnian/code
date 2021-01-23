    public string[] GetAllFilesInDirectory(string path, string startsWith, string fileExt)
        {
            string[] filenames = Directory.GetFiles(path, startsWith + "*" + fileExt);
            return filenames;
        
        }
    
