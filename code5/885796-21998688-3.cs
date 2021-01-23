    public class Product 
    {
        public Product()
        {
            Files = new List<HttpPostedFileBase>();
        }
    
        public List<HttpPostedFileBase> Files { get; set; }
        // Rest of model details
    }
