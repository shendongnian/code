        private void GetMyFiles () {
            string rootDirectory = @"" + txtPathToScan.Text + "";
            string extension = "*";
            List<FileInfo> files = GetFilesRecursively (rootDirectory, extension);
 
            Console.WriteLine ("Got {0} files of extension {1} in directory {2}", files.Count, extension, rootDirectory);
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file);
                var info = new System.IO.FileInfo(@"" + file + "");
                Console.WriteLine("For file {0}", info.Name);
                Console.WriteLine("Length is {0} KB", info.Length/1024);
                Console.WriteLine("Creation time is {0}", info.CreationTime);
                Console.WriteLine("Last access time is {0}", info.LastAccessTime);
                Console.WriteLine("Last write time is {0}", info.LastWriteTime);
            }
        }
 
        /// <summary>
        /// This function calls itself recursively for each of the subdirectories that it finds
        /// in the root directory passed to it. It returns files of the extension as specified
        /// by the caller.
        /// </summary>
        /// <param name="rootDirectory">The directory from which the file list is sought.</param>
        /// <param name="extension">The particular extension for which the file list is sought.</param>
        /// <returns>A list of all the files with extension as specified by the caller. This list
        /// includes the files in the current directory as well its sub-directories.</returns>
        static List<FileInfo> GetFilesRecursively(string rootDirectory, string extension)
        {
            // Uncomment this line only if you want to trace the control as it goes from
            // sub-directory to sub-directory. Be ready for long scrolls of text output:
            //Console.WriteLine ("Currently in directory {0}", rootDirectory);
 
            // Create an output list:
            List<FileInfo> opList = new List<FileInfo>();
 
            // Get all files in the current directory:
            string[] allFiles = Directory.GetFiles (rootDirectory, "*." + extension);
 
            // Add these files to the output list:
            opList.AddRange(allFiles.Select(f => new FileInfo(f)));
 
            // Get all sub-directories in current directory:
            string[] subDirectories = Directory.GetDirectories (rootDirectory);
 
            // And iterate through them:
            foreach (string subDir in subDirectories) {
                // Get all the files from the sub-directory:
                List<FileInfo> subDirFileList = GetFilesRecursively (subDir, extension);
                // And add it to this list:
                opList.AddRange (subDirFileList);
            }
 
            // Finally return the output list:
            return opList;
        }
