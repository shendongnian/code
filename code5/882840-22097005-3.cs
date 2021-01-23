    if (folderId == null)   // It is root public folder
            {
                var mailboxGuid= GetMailboxId();
                var ewsFolderId = EwsAdapter.GetPublicFolderId(folderId); // public folder root
                List<Folder> tempFindFolderResults;
                tempFindFolderResults = FindFolders(ewsFolderId); // get all root public folders from all public folder mailboxes
                var powerShellConnection = new powerShellConnection(ConnectionConfiguration);
                var PublicFolderMailboxes = powerShellConnection.GetPublicFolders(); // get all root public folders with info which mailbox is owner
               
                foreach (var PublicFolderMailbox in PublicFolderMailboxes)
                {
                    if ((PublicFolderMailbox.Attributes["ExchangeMailboxGuid"].Value.Equals(mailboxGuid))
                    {
                        foreach (var tempFindFolderResult in tempFindFolderResults)
                        {
                            if (tempFindFolderResult.DisplayName.Equals(PublicFolderMailbox.Attributes["Name"].Value)
                            {
                                findFolderResults.Add(tempFindFolderResult);  // add only folder from selected public folder mailbox
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
