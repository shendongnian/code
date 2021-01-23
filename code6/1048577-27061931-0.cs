     internal class FTPFileManager : IFileManager<IFile>
        {
            public void SaveFile(IFile file) { }
        }
    public class FileManagerFactory
        {
            public static IFileManager<IFile> GetFileManager(IFile file)
            {
                if (file is FTPFile)
                    return new FTPFileManager();                 
            }
        }
