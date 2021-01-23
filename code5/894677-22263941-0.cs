    IEnumerable<File> FindByKeywords(IEnumerable<Keyword> keywords)
    {
        var foundFiles = new List<File>();
    
        foreach (File file in Context.Files)
        {
            foreach (string fileWord in file)
            {
                foreach (string keyword in keywords)
                {
                    if (fileWord == keyword)
                    {
                        foundFiles.Add(file);
                        break;
                    }
                }
            }
        }
    
        return foundFiles;
    }
