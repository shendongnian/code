    public static IEnumerable<FileEntryInfo> EnumerateFindFileSystemEntries(string entryToFind, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase, DirectoryInfo rootDir = null, string[] drivesToSearch = null)
    {
        List<FileEntryInfo> foundFiles = new List<FileEntryInfo>();
        if (rootDir != null && drivesToSearch != null)
            throw new ArgumentException("Specify either the root-dir or the drives to search, not both");
        else if (rootDir != null)
        {
            foundFiles.AddRange(EnumerateFindEntryRoot(entryToFind, rootDir, comparison));
        }
        else
        {
            if (drivesToSearch == null) // search the entire computer
                drivesToSearch = System.Environment.GetLogicalDrives();
            foreach (string dr in drivesToSearch)
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                rootDir = di.RootDirectory;
                foundFiles.AddRange(EnumerateFindEntryRoot(entryToFind, rootDir, comparison));
            }
        }
        return foundFiles;
    }
    public class FileEntryInfo
    {
        public FileEntryInfo(string path, int number)
        {
            this.Path = path;
            this.Number = number;
            this.Tree = new List<FileEntryInfo>();
        }
        public int Number { get; set; }
        public string Path { get; set; }
        public IList<FileEntryInfo> Tree { get; set; }
        public IEnumerable<int> GetNumberTree()
        {
            foreach (FileEntryInfo entry in this.Tree)
                yield return entry.Number;
        }
        public override bool Equals(object obj)
        {
            FileEntryInfo fei = obj as FileEntryInfo;
            if(obj == null) return false;
            return Number == fei.Number && Path == fei.Path;
        }
        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }
        public override string ToString()
        {
            return Path;
        }
    }
    private static IEnumerable<FileEntryInfo> EnumerateFindEntryRoot(string fileNameToFind, DirectoryInfo rootDir, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase)
    {
        Queue<FileEntryInfo> queue = new Queue<FileEntryInfo>();
        FileEntryInfo root = new FileEntryInfo(rootDir.FullName, 1);
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            FileEntryInfo fe = queue.Dequeue();
            int entryCount = 0;
            List<FileEntryInfo> validEntries = new List<FileEntryInfo>();
            try
            { // you cannot yield from try-catch, hence this approach
                FileAttributes attr = File.GetAttributes(fe.Path);
                //detect whether its a directory or file
                bool isDirectory = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                if (isDirectory)
                {
                    foreach (string entry in Directory.EnumerateFileSystemEntries(fe.Path))
                    {
                        entryCount++;
                        FileEntryInfo subEntry = new FileEntryInfo(entry, entryCount);
                        fe.Tree.Add(subEntry);
                        queue.Enqueue(subEntry);
                        validEntries.Add(subEntry);
                    }
                }
            } catch (Exception ex)
            {
                Console.Error.WriteLine(ex); // ignore, proceed
            }
            foreach (FileEntryInfo entry in validEntries)
            {
                if (entry.Path.Equals(fileNameToFind, comparison))
                    yield return entry;
            }
        }
    }
