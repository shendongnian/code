    /// <summary>
    ///   Class FileSystemService - an abstraction over file system services.
    ///   This class consists mainly of virtual methods and exists primarily to aid testability.
    /// </summary>
    public class FileSystemService
        {
        public virtual bool DirectoryExists(string path)
            {
            return Directory.Exists(path);
            }
    
        public virtual string PathCombine(string path1, string path2)
            {
            return Path.Combine(path1, path2);
            }
    
        public virtual string GetFullPath(string path)
            {
            return Path.GetFullPath(path);
            }
    
        public virtual void SaveImage(string path, Bitmap image, ImageFormat format)
            {
            image.Save(path, ImageFormat.Png);
            }
        }
