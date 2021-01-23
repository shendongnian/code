    // Some stuff elided for clarity
    public class with_fake_filesystem_service
        {
        Establish context = () =>
            {
            Filesystem = A.Fake<FileSystemService>();
            };
    
        protected static FileSystemService Filesystem;
        }
