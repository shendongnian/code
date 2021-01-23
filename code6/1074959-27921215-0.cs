    public class ReverseComparer : IComparer<FileSystemInfo>
            {
                public int Compare(FileSystemInfo x, FileSystemInfo y)
                {
                 return x.CreationTime.CompareTo(y); 
                }
        }
     DirectoryInfo di = new DirectoryInfo("C:\\...");
     FileSystemInfo[] files = di.GetFileSystemInfos();
     Array.Sort(files, new ReverseComparer());
