    var list = web.Lists[new Guid("...")];
    var folderItem = list.RootFolder.SubFolders;
            
    foreach (File f in files) {
        var lastModifiedBy = context.Web.EnsureUser(f.LastModifiedBy);
        var lastModified = f.LastModified;
        SPFile uploadedFile = folderItem.Files.Add(f.FileName, f.Content, lastModifiedBy,
                              lastModifiedBy, lastModified, lastModified);
        uploadedFile.Item["Created"] = lastModified;
        uploadedFile.Item["Modified"] = lastModified;
        uploadedFile.Item.UpdateOverwriteVersion();
    }
