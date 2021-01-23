    IEnumerable<SPFile> GetAllSubContent(SPFolder spFolder)
    {
        foreach (SPFile spFile in spFolder.Files.Cast<SPFile>().Where(f => f.Item != null))
        {
           yield return spFile;
        }
        foreach (SPFolder spSubFolder in spFolder.SubFolders)
        {
            foreach (SPFile spFile in GetAllSubContent(spSubFolder))
            {
               yield return spFile;
            }
        }
    }
