    public class SomeService : ISomeService
    {
        private readonly IFileSystem fileSystem;
        public SomeService(IFileSystem fileSystem)
        {
            if (fileSystem == null) 
                throw new ArgumentNullException("fileSystem");
            this.fileSystem = fileSystem;
        }
        public void DoSomething()
        {
             // The directory can be determined at runtime.
             // It could, for example, be provided by another service.
             string directory = @"C:\SomeWhere\";
    
             // Create an instance of the DirectoryInfoWrapper concrete type.
             DirectoryInfoBase directoryInfo = this.fileSystem.DirectoryInfo.FromDirectoryName(directory);
             // Do something with the directory (it has the exact same interface as
             // System.IO.DirectoryInfo).
             var files = directoryInfo.GetFiles();
        }
    }
