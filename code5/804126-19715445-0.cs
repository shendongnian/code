        static void Main(string[] args)
        {
            var mainDirectory = new DirectoryInfo("C:\\");
            var files = GetFiles(mainDirectory, ".");
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
            Console.ReadKey();
        }
        static IEnumerable<DirectoryInfo> GetDirectories(DirectoryInfo parentDirectory)
        {
            DirectoryInfo[] childDirectories = null;
            try
            {
                childDirectories = parentDirectory.GetDirectories();
            }
            catch (Exception)
            {
                
            }
            yield return parentDirectory;
            if (childDirectories != null)
            {
                foreach (var childDirectory in childDirectories)
                {
                    var childDirectories2 = GetDirectories(childDirectory);
                    foreach (var childDirectory2 in childDirectories2)
                    {
                        yield return childDirectory2;
                    }
                }
            }
        }
        static IEnumerable<FileInfo> GetFiles(DirectoryInfo parentDirectory, 
                                              string searchPattern)
        {
            var directories = GetDirectories(parentDirectory);
            foreach (var directory in directories)
            {
                FileInfo[] files = null;
                try
                {
                    files = directory.GetFiles(searchPattern);
                }
                catch (Exception)
                {
                }
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        yield return file;
                    }
                }
            }
        }
