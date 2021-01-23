    public class UploadFileModel //: IEnumerable
        {
            [FileSize(10240)]
            [FileTypes("jpg,jpeg,png,pdf")]
            public HttpPostedFileBase File { get; set; }
    
            public void Save() { 
            
            //Put your Saving Logic
            }
    
        }
    
        // An Extension method for operating files
    
        public static class Extensions{
            public static void PerformSave (this IEnumerable<UploadFileModel> collection){
    
    
                foreach (var item in collection)
                {
                    item.Save();
                }
    
         }
    
       }
