    public class SPDataAccess
    {
    
        public SPDataAccess(SP.ClientContext ctx)
        {
            Context = ctx;
        }
    
        public LibraryAndFolderInfo GetLibraryAndFolderInfo(Guid documentGuid)
        {
            var file = Context.Web.GetFileById(documentGuid);
            var item = file.ListItemAllFields;
            var list = item.ParentList;
            Context.Load(list, l => l.Title, l => l.RootFolder);
            Context.Load(item);
            Context.ExecuteQuery();
    
    
            var info = new LibraryAndFolderInfo();
            var folderUrl = (string)item["FileDirRef"];
            info.LibraryName = list.Title; //list title
            info.LibraryBaseUrl = list.RootFolder.ServerRelativeUrl; //list url  
            if (folderUrl.Replace(list.RootFolder.ServerRelativeUrl, string.Empty).Length > 0)
            {
                info.FolderName = folderUrl.Split('/').Last(); //folder name
                info.FolderUrl = folderUrl;
            }
    
            return info;
        }
    
        protected SP.ClientContext Context { get; private set; }
    }
