    public class ErrorHttpHandler : IHttpHandler
        {
            public bool IsReusable
            {
                get { return true; }
            }
     
            public void ProcessRequest(HttpContext context)
            {
                if (context.Request.QueryString.Count == 0)
                    return;
     
                string strStatusCode = context.Request.QueryString[0].Split(';').FirstOrDefault() ?? "500";
                int statusCode = 500;
                int.TryParse(strStatusCode, out statusCode);
     
                string message = "Unhandled server error.";
     
                switch (statusCode)
                {
                    case 400:
                        message = "Bad request.";
                        break;
     
                    case 404:
                        message = "Item not found.";
                        break;
                }
     
                context.Response.StatusCode = statusCode;
                context.Response.Write(string.Format("<Error><Message>{0}</Message></Error>", message));
            }
        }
