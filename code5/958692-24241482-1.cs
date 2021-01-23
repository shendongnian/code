    // Get a list of the folders.
    // We do this, in order to avoid the performance hit, that Panagiotis 
    // pointed out correctly in his comment.
    var folders = repo.Folders.ToList();
    // Get the root folder.
    var rootFolder = folders.Where(x=>x.idParent==null).SingleOrDefault();
    // Group the folders by their parentId.
    var groupedFolders = from folder in folders
                         where folder.idParent!=null
                         orderby folder.idParent ascending
                         group folder by folder.idParent into grp
                         select new
                         {
                             ParentFolderId = grp.Key,
                             Folders = grp.Select(x=>x)
                         };
    // Print the name of the root folder.
    Console.WriteLine("Root Folder", rootFolder.Name);
    // Iterate through the groups of folders. 
    foreach(var grp in groupedFolders)
    {
        // Get the name of the parent folder for the current group.
        string parentFolderName = folders.Where(x=>x.Id==grp.ParentFolderId)
                                         .Single(x=>x.Name);
        
        // Print the name of the parent folder.
        Console.WriteLine("Parent Folder", parentFolderName);
        // Iterate through the folders of the current group.
        foreach(var folder in grp.Folders)
        {
            Console.WriteLine(folder.Name);
        }
    }
