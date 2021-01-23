    public class User : IHttpHandler
    {
      public void ProcessRequest(HttpContext context)
      {
         JavaScriptSerializer serializer = new JavaScriptSerializer();
         context.Response.ContentType = "text/html";
         var currentUser = DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo();
         var serUser = javaScriptSerializer.Serialize(currentUser);
         context.Response.Write(serUser);
      }
      public bool IsReusable
      {
        get
        {
            return false;
        }
      }
    }
