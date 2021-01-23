    public class EmailHandler : IHttpHandler
    {
    
        public void ProcessRequest(HttpContext context)
        {
           string email = context.Request.Form["email"];
           string content = context.Request.Form["content"];
    
           SendEmail(email,content);
        }
    
        private void SendEmail(string address, string content)
        {
            ...
        }
    
    }
