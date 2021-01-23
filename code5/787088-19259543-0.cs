        /// <summary>
        /// method to provide a relative path from a directory to a path
        /// </summary>
        /// <param name="fromDirectory">the starting folder</param>
        /// <param name="toPath">the path that will be pointed to</param>
        /// <returns>string</returns>
        public static string RelativePathTo(string fromDirectory, string toPath)
        {
            if (fromDirectory == null)
            {
                throw new ArgumentNullException("fromDirectory");
            }
            if (toPath == null)
            {
                throw new ArgumentNullException("fromDirectory");
            }
            if (System.IO.Path.IsPathRooted(fromDirectory) && System.IO.Path.IsPathRooted(toPath))
            {
                if (string.Compare(System.IO.Path.GetPathRoot(fromDirectory)
                    , System.IO.Path.GetPathRoot(toPath), true) != 0)
                {
                    throw new ArgumentException(
                        String.Format("The paths '{0} and '{1}' have different path roots."
                            , fromDirectory
                            , toPath));
                }
            }
            StringCollection relativePath = new StringCollection();
            string[] fromDirectories = fromDirectory.Split(System.IO.Path.DirectorySeparatorChar);
            string[] toDirectories = toPath.Split(System.IO.Path.DirectorySeparatorChar);
            int length = Math.Min(fromDirectories.Length, toDirectories.Length);
            int lastCommonRoot = -1;
            // find common root
            for (int x = 0; x < length; x++)
            {
                if (string.Compare(fromDirectories[x], toDirectories[x], true) != 0)
                {
                    break;
                }
                lastCommonRoot = x;
            }
            if (lastCommonRoot == -1)
            {
                throw new ArgumentException(
                    string.Format("The paths '{0} and '{1}' do not have a common prefix path."
                        , fromDirectory
                        , toPath));
            }
            // add relative folders in from path
            for (int x = lastCommonRoot + 1; x < fromDirectories.Length; x++)
            {
                if (fromDirectories[x].Length > 0)
                {
                    relativePath.Add("..");
                }
            }
            // add to folders to path
            for (int x = lastCommonRoot + 1; x < toDirectories.Length; x++)
            {
                relativePath.Add(toDirectories[x]);
            }
            // create relative path
            string[] relativeParts = new string[relativePath.Count];
            relativePath.CopyTo(relativeParts, 0);
            string newPath = string.Join(System.IO.Path.DirectorySeparatorChar.ToString(), relativeParts);
            return newPath;
        }
