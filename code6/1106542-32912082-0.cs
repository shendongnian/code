        public bool FolderExists(string library, string name) {
            using (var ctx = SPStatic.Context(_sharePointSiteUrl)) {
                
                List sharedDocs = ctx.Web.Lists.GetByTitle(library);
                var query = ctx.LoadQuery(sharedDocs.RootFolder.Folders.Where(fd => fd.Name == name));
                ctx.ExecuteQuery();
                Folder f = query.SingleOrDefault();
                return f != null;
            }
        }
