    namespace Site.Models
    {
    public class Issue
    {
        String FilePath { get; set; }
        String FileName { get; set; }
        String HTML {get; set;}
        public Issue(String filename)
        {
            HTML = "<li>" + FileName + "</li>;
        }
        public static Issue getIssue(String path)
        {
            FilePath = path;
            FileName = Path.GetFileName(FilePath);
            if(!FileName.StartsWith("."){
                return new Issue(FileName);
            }
            else
            {
                //throw exception or whatever you want to do to handle it
            }
         }
    }
    }
