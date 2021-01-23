    public class UploadFileModel 
    {
        public UploadFileModel()
        {
            Files = new List<HttpPostedFileBase>();
        }
    
        public List<HttpPostedFileBase> Files { get; set; }
        
    }
