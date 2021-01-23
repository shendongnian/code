    if (folderId == null)   // It is root public folder
    {
        var mailboxGuid = GetMailboxId();
        // public folder root
        var ewsFolderId = EwsAdapter.GetPublicFolderId(folderId);
        // get all root public folders from all public folder mailboxes
        var tempFindFolderResults = FindFolders(ewsFolderId);
        var powerShellConnection = new powerShellConnection(ConnectionConfiguration);
        // get all root public folders with info which mailbox is owner
        var PublicFolderMailboxes = powerShellConnection.GetPublicFolders();
       
        foreach (var publicFolderMailbox in PublicFolderMailboxes)
        {
            if (publicFolderMailbox.Attributes["ExchangeMailboxGuid"].Value == mailboxGuid)
            {
                foreach (var tempFindFolderResult in tempFindFolderResults)
                {
                    if (tempFindFolderResult.DisplayName == publicFolderMailbox.Attributes["Name"].Value)
                    {
                        // add only folder from selected public folder mailbox
                        findFolderResults.Add(tempFindFolderResult);
                    }
                }
            }
        }
    }
    else  // it is public subfolder - standard handling
    {
        var ewsFolderId = EwsAdapterHelper.GetPublicFolderId(folderId);
        findFolderResults = FindFolders(ewsFolderId);
    }
