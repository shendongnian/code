    private static void GetFolderHierarchy(int folderViewSize, ExchangeService service)
        {
            FolderView view = new FolderView(folderViewSize);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly, FolderSchema.DisplayName);     
           
            // Call FindFolders to retrieve the folder hierarchy, starting with the PublicFoldersRoot folder.
            FindFoldersResults findResults = service.FindFolders(WellKnownFolderName.PublicFoldersRoot, view);
            foreach (Folder folder in findResults.Folders)
            {
                 Console.WriteLine("Public folder display name: {0} ", folder.DisplayName);
                
            }
       }
