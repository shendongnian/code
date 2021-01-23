    [Route("/content/{filePath*}", "GET")] 
    public class ContentRequest : IReturnVoid 
    { 
        public string filePath { get; set; } 
    } 
    
    public class ContentService : Service 
    { 
        public void Get(ContentRequest request) 
        { 
            var fullPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Content", request.filePath); 
            Response.WriteFile(fullPath); 
            Response.End(); 
        } 
    }
