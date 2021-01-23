    [Serializable]
    public class DirectoryInfoFactory : IDirectoryInfoFactory
    {
        public DirectoryInfoBase FromDirectoryName(string directoryName)
        {
            var realDirectoryInfo = new DirectoryInfo(directoryName);
            return new DirectoryInfoWrapper(realDirectoryInfo);
        }
    }
    public class SomeService : ISomeService
    {
        private readonly IDirectoryInfoFactory directoryInfoFactory;
        public SomeService(IDirectoryInfoFactory directoryInfoFactory)
        {
            if (directoryInfoFactory == null) 
                throw new ArgumentNullException("directoryInfoFactory");
            this.directoryInfoFactory = directoryInfoFactory;
        }
        public void DoSomething()
        {
             // The directory can be determined at runtime.
             // It could, for example, be provided by another service.
             string directory = @"C:\SomeWhere\";
    
             // Create an instance of the DirectoryInfoWrapper concrete type.
             DirectoryInfoBase directoryInfo = this.directoryInfoFactory.FromDirectoryName(directory);
             // Do something with the directory (it has the exact same interface as
             // System.IO.DirectoryInfo).
             var files = directoryInfo.GetFiles();
        }
    }
