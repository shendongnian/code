        var data = GetAllFilesOfType('c:\rootpath', 'csv')
    /// <summary>
        /// Gets files of specified type and appends them to the file list.
        /// </summary>
        /// <param name="basepath">Starting file path</param>
        /// <param name="type">File type - Do not include prefix ('txt' instead of '*.txt</param>
        /// <returns>Returns results of WalkDirectoryTree</returns>
        public static IEnumerable<FileInfo[]> GetAllFilesOfType(string basepath, string type)
        {
            var root = new DirectoryInfo(basepath);
            return WalkDirectoryTree(root, type);
        }
    /// <summary>
        /// Recursively gets all files from a specified basepath (provided by GetAllFilesOfType)
        /// and appends them to a file list. This method reports all errors, and will break on
        /// things like security errors, non existant items, etc.
        /// </summary>
        /// <param name="root">Initially specified by calling function, set by recursive walk</param>
        /// <param name="type">File type that is desired. Do not include prefix ('txt' instead of '*.txt')</param>
        /// <returns></returns>
        private static List<FileInfo[]> WalkDirectoryTree(DirectoryInfo root, string type)
        {
            var files = new List<FileInfo[]>();
            //Traverse entire directory tree recursively - Will break on exception
            var subDirs = root.GetDirectories();
            foreach (var data in subDirs.Select(dirInfo => WalkDirectoryTree(dirInfo, type)).Where(data => data.Count > 0))
            {
                files.AddRange(data);
            }
            //If any file is found, add it to the file list
            if (root.GetFiles(string.Format("*.{0}", type)).Length > 0)
            {
                files.Add(root.GetFiles(string.Format("*.{0}", type)));
            }
            //Kicks the file list up a level until it reaches root, then returns to calling function
            return files;
        }
