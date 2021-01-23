    public class Issue
        {
            String FilePath { get; set; }
            String FileName { get; set; }
            String HTML {get; set;}
    
            Exception NotIssueException;
    
            public Issue(String path)
            {
                NotIssueException = new Exception("Not an Issue Exception");
                FilePath = path;
                FileName = Path.GetFileName(FilePath);
    
                if(!FileName.StartsWith("."))
                {
                    throw NotIssueException;
                }
                else
                {
                    //Do Your Logic
                }
    
                HTML = "<li>" + FileName + "</li>;
            }
        }
