    public class ModelToCreate
    {
        //Some properties
        public FileUploadModel Files { get; set; }
    }
        
    public class FileUploadModel
    {
       public FileUploadModel()
       {
            Files = new List<HttpPostedFileBase>();
       }
        
       public List<HttpPostedFileBase> Files { get; set; }
    }
    
