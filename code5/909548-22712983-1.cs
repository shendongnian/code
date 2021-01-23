    public class AModel 
    {
        public AModel()
        {
            Files = new List<HttpPostedFileBase>();
        }
    
        public List<HttpPostedFileBase> Files { get; set; }
        // Rest of model details
    }
