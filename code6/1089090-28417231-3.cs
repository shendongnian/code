    public class MyController : MyBaseController {
    
        [HttpPost]
        public FileContentResult GenerateDocument(string fileName) {
            string html = "<h1>Title</h1><p>Content goes here!</p>";
            return Html2DocxResult(html, fileName);
        }
    
    }
