    class FileNamingFactory
    {
        // Initialize the first and second instances (maybe in a static contructor)
        private static Filenaming FileNaming1;
        private static Filenaming FileNaming2;
        static Filenaming GetFileNaming(FileNamingOptions fileNaming)
        {
            if (fileNaming == FileNamingOptions.Naming1)
            {
                return FileNaming1;
            }
            else if (fileNaming == FileNamingOptions.Naming2)
            {
                return FileNaming2;
            }
            return null;
        }
        enum FileNamingOptions
        {
            Naming1,
            Naming2
        }
    }
