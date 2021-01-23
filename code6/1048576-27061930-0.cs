    public interface IFile { }
    
    public class FTPFile : IFile { }
    
    public interface IFileManager
    {
        void SaveFile(IFile file);
    
        bool Accepts(IFile file);
    }
    
    public abstract class FileManager<TFile>
        : IFileManager
        where TFile : IFile
    {
        protected abstract void SaveFile(TFile file);
    
        public void SaveFile(IFile file)
        {
            var cast = (TFile)file; // will throw a compile exception if wrong one
    
            this.SaveFile(cast);
        }
    
        public bool Accepts(IFile file)
        {
            return file is TFile;
        }
    }
    
    internal class FTPFileManager : FileManager<FTPFile>
    {
        protected sealed override void SaveFile(FTPFile file)
        {
            Console.WriteLine("Saved file");
        }
    }
    
    public static IFileManager GetFileManager(IFile file)
    {
        var managers = new List<IFileManager> { new FTPFileManager() };
    
        return managers.Single(manager => manager.Accepts(file));
    }
