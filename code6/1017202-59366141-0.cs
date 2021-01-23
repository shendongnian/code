    public class ImageHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
            {
                public void ProcessRequest(HttpContext context)
                {
                  string Name = "";
                  if (context.Session["mysessionvar"] != null)
                     Name = context.Session["mysessionvar"].ToString();
                }
            }
