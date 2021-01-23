    class SomeClassThatNeedsTheFileSystem
        {
        public SomeClassThatNeedsTheFileSystem(FileSystemService filesystem = null)
            {
            fileSystem = filesystem ?? new FileSystemService();
            }
        }
