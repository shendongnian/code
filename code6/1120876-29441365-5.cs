     public partial class SystemDesign
        {
            public string URL { get; set; }
     
    
            public SystemDesign() { }
    
            public SystemDesign (string url, string directory)
            {
                this.URL = url;
             
            }
    
            public static SystemDesign returnImageURL(IListBlobItem item)
            {
    
                if (item is CloudBlockBlob)
                {
                    var blob = (CloudBlockBlob)item;
                    return new SystemDesign 
                    {   URL = blob.Uri.ToString(),
                       
                    };
    
                }
                return null;
            }
    
        }   
        
    
        // System Design Model 
        public partial class SystemDesignModel
        {
            public SystemDesignModel() : this(null)
            {
                Files = new List<SystemDesign>();
            }
    
            public SystemDesignModel(IEnumerable<IListBlobItem> list)
            {
                Files = new List<SystemDesign>();
    
                foreach (var item in list)
                    {
                        SystemDesign test = SystemDesign.returnImageURL(item);
                        Files.Add(test);
                      
                    }
                
               
            }
            public List<SystemDesign> Files { get; set; }
        }
       
    
    
