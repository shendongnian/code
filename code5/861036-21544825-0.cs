           PropertySet propSet = new PropertySet(BasePropertySet.FirstClassProperties, FolderSchema.Permissions);
           Folder folder = Folder.Bind(service, folderid, propSet);
           if (folder.Permissions.Count != 0)
            {
                for (int t = 0; t < folder.Permissions.Count; t++)
                {
                    // Find any permissions associated with the specified user and remove them from the DACL
                    if (folder.Permissions[t].UserId.DisplayName != null || folder.Permissions[t].UserId.PrimarySmtpAddress != null)
                    {
                        folder.Permissions.Remove(folder.Permissions[t]);
                    }
                }
            }
            //Now add the new permissions to the DACL 
            FolderPermission fldperm = new FolderPermission("sadied@contoso.onmicrosoft.com", FolderPermissionLevel.PublishingAuthor);
            folder.Permissions.Add(fldperm);
            folder.Update(); 
