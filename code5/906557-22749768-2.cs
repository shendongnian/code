        // Any and all directories specified in path are created, unless they already exist or unless 
        // some part of path is invalid. If the directory already exists, this method does not create a 
        // new directory.
        // The path parameter specifies a directory path, not a file path, and it must in 
        // the ApplicationData domain.
        // Trailing spaces are removed from the end of the path parameter before creating the directory.
        public static void CreateDirectory(string path)
        {
             path = path.Replace('/', '\\').TrimEnd('\\');
            StorageFolder folder = null;
            foreach(var f in new StorageFolder[] {
                ApplicationData.Current.LocalFolder, 
                ApplicationData.Current.RoamingFolder, 
                ApplicationData.Current.TemporaryFolder } )
            {
                string p = ParsePath(path, f);
                if (f != null)
                {
                    path = p;
                    folder = f;
                    break;
                }
            }
            if(path == null)
                throw new NotSupportedException("This method implementation doesn't support " +
                "parameters outside paths accessible by ApplicationData.");
            string[] folderNames = path.Split('\\');
            for (int i = 0; i < folderNames.Length; i++)
            {
                var task = folder.CreateFolderAsync(folderNames[i], CreationCollisionOption.OpenIfExists).AsTask();
                task.Wait();
                if (task.Exception != null)
                    throw task.Exception;
                folder = task.Result;
            }
        }
        private static string ParsePath(string path, StorageFolder folder)
        {
            if (path.Contains(folder.Path))
                {
                    path = path.Substring(path.LastIndexOf(folder.Path) + folder.Path.Length + 1);
                    return path;
                }
            return null;
        }
