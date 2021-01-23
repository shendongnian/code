    public static IEnumerable<FileEntryInfo> EnumerateFindFiles(string fileToFind, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase, DirectoryInfo rootDir = null, string[] drivesToSearch = null)
    {
        IEnumerable<FileEntryInfo> foundEntries = Enumerable.Empty<FileEntryInfo>();
        if (rootDir != null && drivesToSearch != null)
            throw new ArgumentException("Specify either the root-dir or the drives to search, not both");
        else if (rootDir != null)
        {
            foundEntries = EnumerateFindEntryRoot(fileToFind, rootDir, comparison);
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
                foundEntries = foundEntries.Concat(EnumerateFindEntryRoot(fileToFind, rootDir, comparison));
            }
        }
        foreach (FileEntryInfo entry in foundEntries)
            yield return entry;
    }
    public class FileEntryInfo
    {
        public FileEntryInfo(string path, int number)
        {
            this.Path = path;
            this.Number = number;
        }
        public int Number { get; set; }
        public string Path { get; set; }
        public FileEntryInfo Root { get; set; }
        public IEnumerable<int> GetNumberTree()
        {
            Stack<FileEntryInfo> filo = new Stack<FileEntryInfo>();
            FileEntryInfo entry = this;
            while (entry.Root != null)
            {
                filo.Push(entry.Root);
                entry = entry.Root;
            }
            while(filo.Count > 0)
                yield return filo.Pop().Number;
            yield return this.Number; 
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
            List<FileEntryInfo> validFiles = new List<FileEntryInfo>();
            try
            { // you cannot yield from try-catch, hence this approach
                FileAttributes attr = File.GetAttributes(fe.Path);
                //detect whether its a directory or file
                bool isDirectory = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                if (isDirectory)
                {
                    int entryCount = 0;
                    foreach (string entry in Directory.EnumerateFileSystemEntries(fe.Path))
                    {
                        entryCount++;
                        FileEntryInfo subEntry = new FileEntryInfo(entry, entryCount);
                        subEntry.Root = fe;
                        queue.Enqueue(subEntry);
                        attr = File.GetAttributes(entry);
                        isDirectory = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                        if(!isDirectory)
                            validFiles.Add(subEntry);
                    }
                }
            } catch (Exception ex)
            {
                Console.Error.WriteLine(ex); // ignore, proceed
            }
            foreach (FileEntryInfo entry in validFiles)
            {
                string fileName = Path.GetFileName(entry.Path);
                if (fileName.Equals(fileNameToFind, comparison))
                    yield return entry;
            }
        }
    }
