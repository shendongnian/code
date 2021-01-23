    public class GetHtmlHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // Grab the drop down list variable value from the query string
            // Use controls to build table or do it via StringBuilder
            return htmlString;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
