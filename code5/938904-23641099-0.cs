    [Export(typeof(IFileLoader))]
    [FileType(FileExtension = ".jpg")]
    public class JpgFileLoader : IFileLoader
    {
        public string LoadFile()
        {
            return "JPG"; 
        }
    }
    [Export(typeof(IFileLoader))]
    [FileType(FileExtension = ".png")]
    public class PngFileLoader : IFileLoader
    {
        public string LoadFile()
        {
            return "PNG";
        }
    }
