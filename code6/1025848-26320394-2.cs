    public static class FolderExtensions
    {
     
        public static void MoveFilesTo(this Folder folder, string folderUrl)
        {
            var ctx = (ClientContext)folder.Context;
            if (!ctx.Web.IsPropertyAvailable("ServerRelativeUrl"))
            {
                ctx.Load(ctx.Web, w => w.ServerRelativeUrl);   
            }
            ctx.Load(folder, f => f.Files, f => f.ServerRelativeUrl, f => f.Folders);
            ctx.ExecuteQuery();
            //Ensure target folder exists
            EnsureFolder(ctx.Web.RootFolder, folderUrl.Replace(ctx.Web.ServerRelativeUrl, string.Empty));
            foreach (var file in folder.Files)
            {
                var targetFileUrl = file.ServerRelativeUrl.Replace(folder.ServerRelativeUrl, folderUrl);
                file.MoveTo(targetFileUrl, MoveOperations.Overwrite);
            }
            ctx.ExecuteQuery();
            foreach (var subFolder in folder.Folders)
            {
                var targetFolderUrl = subFolder.ServerRelativeUrl.Replace(folder.ServerRelativeUrl,folderUrl);
                subFolder.MoveFilesTo(targetFolderUrl);
            }
        }
      
        public static Folder EnsureFolder(Folder parentFolder, string folderUrl)
        {
            var ctx = parentFolder.Context;
            var folderNames = folderUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var folderName = folderNames[0];
            var folder = parentFolder.Folders.Add(folderName);
            ctx.Load(folder);
            ctx.ExecuteQuery();
            if (folderNames.Length > 1)
            {
                var subFolderUrl = string.Join("/", folderNames, 1, folderNames.Length - 1);
                return EnsureFolder(folder, subFolderUrl);
            }
            return folder;
        }
    }
