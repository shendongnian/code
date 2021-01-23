        static void Main(string[] args)
        {
            var baseDirectory = ".";
            DeleteEmptyDirectory(baseDirectory);
        }
        static bool DeleteEmptyDirectory(string directory)
        {
            var subDirs = Directory.GetDirectories(directory);
            var canDelete = true;
            if (subDirs.Any())
                foreach (var dir in subDirs)
                    canDelete = DeleteEmptyDirectory(dir) && canDelete;
            if (!Directory.GetFiles(directory).Any() && canDelete)
            {
                Directory.Delete(directory);
                return true;
            }
            else
                return false;
        }
