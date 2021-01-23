    public class Token
    {
      public static string Value
      {
        get
        {
          return System.Web.HttpContext.Current.Request["token"];
        }
      }
    }
    
    public ActionResult MyAction(long? personId) 
    { 
      // I can check the token's value or manipulate it, eg:
      if (Token.Value.Equals(...)) { .. }
    }
