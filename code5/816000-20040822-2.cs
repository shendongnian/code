    public interface IFileRepository
    {
        Stream GetFile(string fileName);
        void PutFile(Stream fileStream, string fileName);
    }
    public class FileRepository
    {
        private readonly string localPath;
        public FileRepository(string localPath)
        {
            _localPath = localPath;
        }
        public Stream GetFile(string fileName)
        {
            var file = //get filestram from harddrive using fileName and localPath
            return file;
        }
        ...
        public void PutFile(Stream fileStream, string fileName)
        {
            //save input stream to disk file using fileName and localPath
        }
    }
