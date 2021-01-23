    internal static class SPFolderExtensions
    {
        /// <summary>
        /// Ensure SPFolder
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listTitle"></param>
        /// <param name="folderUrl"></param>
        /// <returns></returns>
        public static SPFolder CreateFolder(this SPWeb web, string listTitle, string folderUrl)
        {
            if (string.IsNullOrEmpty(folderUrl))
                throw new ArgumentNullException("folderUrl");
            var list = web.Lists.TryGetList(listTitle);
            return CreateFolderInternal(list, list.RootFolder, folderUrl);
        }
        private static SPFolder CreateFolderInternal(SPList list, SPFolder parentFolder, string folderUrl)
        {
            var folderNames = folderUrl.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            var folderName = folderNames[0];
            var curFolder =
                parentFolder.SubFolders.Cast<SPFolder>()
                            .FirstOrDefault(
                                f =>
                                System.String.Compare(f.Name, folderName, System.StringComparison.OrdinalIgnoreCase) ==
                                0);
            if (curFolder == null)
            {
                var folderItem = list.Items.Add(parentFolder.ServerRelativeUrl, SPFileSystemObjectType.Folder,
                                                folderName);
                folderItem.SystemUpdate();
                curFolder = folderItem.Folder;
            }
            if (folderNames.Length > 1)
            {
                var subFolderUrl = string.Join("/", folderNames, 1, folderNames.Length - 1);
                return CreateFolderInternal(list, curFolder, subFolderUrl);
            }
            return curFolder;
        }
    }
