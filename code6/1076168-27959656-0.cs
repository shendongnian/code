    [Route("/textfile-test")]
    public class TextFileTest
    {
        public bool AsAttachment { get; set; }
    }
    public class MyServices : Service
    {
        public object Any(TextFileTest request)
        {
            return new HttpResult(new FileInfo("~/textfile.txt".MapHostAbsolutePath()), 
                asAttachment:request.AsAttachment);
        }
    }
