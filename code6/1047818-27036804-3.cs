    public class MvcApplication : HttpApplication
    { 
      ... 
     public override string GetVaryByCustomString(HttpContext context, string custom)
     {
   
        if (custom == "session") return context.Session.SessionID;
        return base.GetVaryByCustomString(context, custom);
     }
