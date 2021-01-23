        public static string GetRelativeParentPath(string basePath, string path)
        {
            return GetRelativePath(basePath, Path.GetDirectoryName(path));
        }
        public static string GetRelativePath(string basePath, string path)
        {
            // normalize paths
            basePath = Path.GetFullPath(basePath);
            path = Path.GetFullPath(path);
            // same path case
            if (basePath == path)
                return string.Empty;
            // path is not contained in basePath case
            if (!path.StartsWith(basePath))
                return string.Empty;
            // extract relative path
            if (basePath[basePath.Length - 1] != Path.DirectorySeparatorChar)
            {
                basePath += Path.DirectorySeparatorChar;
            }
            return path.Substring(basePath.Length);
        }
