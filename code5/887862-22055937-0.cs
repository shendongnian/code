        public static string GetRelativePath(string sourcePath, string targetPath)
        {
            if (!Path.IsPathRooted(sourcePath)) throw new ArgumentException("Path must be absolute", "sourcePath");
            if (!Path.IsPathRooted(targetPath)) throw new ArgumentException("Path must be absolute", "targetPath");
            string[] sourceParts = sourcePath.Split(Path.DirectorySeparatorChar);
            string[] targetParts = targetPath.Split(Path.DirectorySeparatorChar);
            int n;
            for (n = 0; n < Math.Min(sourceParts.Length, targetParts.Length); n++ )
            {
                if (!string.Equals(sourceParts[n], targetParts[n], StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }
            }
            if (n == 0) throw new ApplicationException("Files must be on the same volume");
            string relativePath = new string('.', sourceParts.Length - n).Replace(".", ".." + Path.DirectorySeparatorChar);
            if (n <= targetParts.Length)
            {
                relativePath += string.Join(Path.DirectorySeparatorChar.ToString(), targetParts.Skip(n).ToArray());
            }
            return string.IsNullOrWhiteSpace(relativePath) ? "." : relativePath;
        }
