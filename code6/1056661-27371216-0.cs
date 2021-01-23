            FolderView cfv = new FolderView(1000);
            cfv.Traversal = FolderTraversal.Shallow;
            SearchFilter cfFilter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName,"OtherContacts");
            FolderId cntfld = new FolderId(WellKnownFolderName.Contacts, "mailbox@domain.com");
            FindFoldersResults ffcResult = service.FindFolders(cntfld, cfFilter, cfv);
            if (ffcResult.Folders.Count == 1) {
                ContactGroup cg = new ContactGroup(service);
                cg.DisplayName = "TestCg";
                cg.Save(ffcResult.Folders[0].Id);
            }
