    public interface IFileRepository
    {
        void SaveFile(HttpPostedFileBase file);
    }
    //concrete implementation
    public class FileRepository : IFileRepository
    {
        public void SaveFile(HttpPostedFileBase file)
        {
            //your file saving logic, ie. file.SaveAs(), etc...
        }
    }
