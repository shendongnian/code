    public static IEnumerable<string> SearchByName(this DirectoryInfo dir, List<string> keywords)
    {
        foreach (FileInfo file in dir.EnumerateFiles())
        {
            string fileName = Path.GetFileNameWithoutExtension(file.Name);
    
            if (keywords.Any(keyword => fileName.Contains(keyword)))
            {
                yield return file.FullName;
            }
        }
    }
