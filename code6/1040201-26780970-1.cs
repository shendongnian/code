    namespace Site.Models
    {
        public class Issue
        {
            String FilePath { get; set; }
            String FileName { get; set; }
            String HTML { get; set; }
            private Issue(String path)
            {
                FilePath = path;
                FileName = Path.GetFileName(path);
                HTML = "<li>" + FileName + "</li>;
            }
            public static Issue CreateIssue(String path)
            {
                
                var fileName = Path.GetFileName(path);
                if (fileName.StartsWith("."){
                     throw new Exception("Not an issue");
                    // or you could return null and handle that in the calling code
                }
                return new Issue(path);
            }
        }
    }
