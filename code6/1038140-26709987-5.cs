        public static string GetFolderByLevel(this string path, string baseFolderPath, int level)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (baseFolderPath == null)
                throw new ArgumentNullException("baseFolderName");
            var pathFolders = path.Split(new char[] {Path.DirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries);
            var basePathFolders = baseFolderPath.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            int baseFolderLevel = -1;
            int folderCounter = 0;
            for (int i = 0; i < pathFolders.Length; ++i)
            {
                if (string.Compare(pathFolders[i], basePathFolders[folderCounter], true) == 0)
                {
                    if (++folderCounter == basePathFolders.Length)
                    {
                        baseFolderLevel = i;
                        break;
                    }
                }
                else
                {
                    folderCounter = 0;
                }
            }
            Debug.Assert(baseFolderLevel > -1);
            Debug.Assert(folderCounter == basePathFolders.Length);
            int index = baseFolderLevel + level;
            if (-1 < index && index < pathFolders.Length)
            {
                return pathFolders[index];
            }
            else
                throw new ArgumentOutOfRangeException(string.Format("Specified level is out of range."));
        }
