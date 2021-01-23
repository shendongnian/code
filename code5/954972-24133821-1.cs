                ExtendedPropertyDefinition PR_Folder_Path = new ExtendedPropertyDefinition(26293, MapiPropertyType.String);
            PropertySet psPropSet = new PropertySet(BasePropertySet.FirstClassProperties);
            psPropSet.Add(PR_Folder_Path);
            FolderId rfRootFolderid = new FolderId(WellKnownFolderName.Root, mbMailboxname);
            FolderView fvFolderView = new FolderView(1000);
            fvFolderView.Traversal = FolderTraversal.Deep;
            fvFolderView.PropertySet = psPropSet;
            SearchFilter sfSearchFilter = new SearchFilter.IsEqualTo(FolderSchema.FolderClass, "IPF.Appointment");
            FindFoldersResults ffoldres = service.FindFolders(rfRootFolderid, sfSearchFilter, fvFolderView);
            if (ffoldres.Folders.Count > 0) {
                foreach (Folder fld in ffoldres.Folders) {
                    Console.WriteLine(fld.DisplayName);
                }
            }
