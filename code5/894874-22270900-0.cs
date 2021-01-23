    ///
    /// This is similar to what you have been doing. It just uses one less extension method call
    ///       
    private bool SkipDirectory()
        {
            return Directory.GetFiles(@"C:\Program Files", "*.txt", SearchOption.AllDirectories).Length > 0;
        }
    ///
    /// The EnumerateFileSystemEntries method itself is quicker than GetFiles but Count method makes it slower
    ///    
    private bool SkipDirectoryEnumerableMethod()
        {
            return (Directory.EnumerateFileSystemEntries(@"C:\Program Files", "*.txt", SearchOption.AllDirectories).Count() > 0);
        }
        ///
        /// This method only search till the first occurrence of text file is spotted.
        private bool SkipDirectory(string path)
        {
            IEnumerable<string> directoryPaths = null;
            bool hasTextFile = false;
            if (directoryPaths == null)
            {
                directoryPaths = Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories);
            }
            foreach (string directoryPath in directoryPaths)
            {
                IEnumerable<string> files = Directory.EnumerateFileSystemEntries(directoryPath, "*.txt", SearchOption.TopDirectoryOnly);
                if (hasTextFile = (files.Count() > 0))
                    break;
            }
            return hasTextFile;
        }
