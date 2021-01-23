    // Get the root folder
    var rootFolder = repo.Folders.Where(x=>x.idParent==null).SingleOrDefault();
    // Group the folders by their parentId
    var groupedFolders = from folder in repo.Folders
                         where folder.idParent!=null
                         orderby folder.idParent ascending
                         group folder by folder.idParent into grp
                         select new
                         {
                             ParentFolderId = grp.Key,
                             Folders = grp.Select(x=>x)
                         };
    Console.WriteLine("Root Folder", rootFolder.Name);
    foreach(var grp in groupedFolders)
    {
        string parentFolderName = repor.Folder.Where(x=>x.Id==grp.ParentFolderId)
                                              .Single(x=>x.Name);
        Console.WriteLine("Parent Folder", parentFolderName);
        foreach(var folder in grp.Folders)
        {
            Console.WriteLine(folder.Name);
        }
    }
