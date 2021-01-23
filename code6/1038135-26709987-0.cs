        public static string GetFolderByLevel(this string path, string baseFolderName, int level)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (baseFolderName == null)
                throw new ArgumentNullException("baseFolderName");
            var pathWithoutFile = Path.GetDirectoryName(path);
            var folders = pathWithoutFile.ToString().Split(Path.DirectorySeparatorChar);
            int baseFolderLevel = -1;
            for (int i = 0; i < folders.Length; ++i)
            {
                if (string.Compare(folders[i], baseFolderName, true) == 0)
                {
                    baseFolderLevel = i;
                    break;
                }
            }
            if (baseFolderLevel == -1)
                throw new ArgumentException(string.Format("Folder '{0}' could not be found in specified path: {1}", baseFolderName, path), "baseFolderName");
            int index = baseFolderLevel + level;
            if (0 > index || index > folders.Length - 1)
                throw new ArgumentOutOfRangeException(string.Format("Specified level is out of range."));
            return folders[index];
        }
