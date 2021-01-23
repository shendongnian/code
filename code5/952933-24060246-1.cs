    public ActionResult ChangeCulture(string value) {
      Response.Cookies.Add(new HttpCookie("culture", value));  
      return View();
    }
    
    public class MvcApplication : HttpApplication {
      protected void Application_BeginRequest() {
        var cookie = Context.Request.Cookies["culture"];
        if (cookie != null && !string.IsNullOrEmpty(cookie.Value)) {
          var culture = new CultureInfo(cookie.Value);
          Thread.CurrentThread.CurrentCulture = culture;
          Thread.CurrentThread.CurrentUICulture = culture;
        }
      }
    }
    
