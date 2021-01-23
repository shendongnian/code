    public class Rewriter
    {
        public Rewriter()
        {
        }
    
        public bool Process()
        {
            // get path from database based on your original path: 
            // use HttpContext.Current.Request.Path and HttpContext.Current.Request.QueryString
            string substPath = "...your db logic here ...";
            HttpContext.Current.RewritePath(substPath);
        }
    }
