    private List<FolderModel> GetFolderSubFolders(IFolderInfo folder)
    {
        var retval = new List<FolderModel>();
        // Foreach subfolder in the given folder
        foreach (var subFolder in FolderManager.Instance.GetFolders(folder))
        {
            // Recall this function
            List<FolderModel> subFolders = GetFolderSubFolders(subFolder);
            // I am assuming that "Bestanden" is also a List<T> and contains
            // the files of this folder
            List<Something> bestanden = GetFolderBestanden(subFolder);
            // Don't do anything if an empty list was returned
            if(subFolders.Count > 0 || bestanden.Count > 0)
            {
                // Create new foldermodel
                var folderModel = new FolderModel
                {
                    FolderName = subFolder.FolderName,
                    Bestanden = bestanden,
                    SubFolders = subFolders
                };
                // Check if we have files and subfolders
                if (folderModel.Bestanden.Any() && folderModel.SubFolders.Any())
                {
                    folderModel.hasFilesAndFolders = true;
                }
                retval.Add(folderModel);
            }
        }
        // If nothing was found this will return an empty list
        return retval;
    }
