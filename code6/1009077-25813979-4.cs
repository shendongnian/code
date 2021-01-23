    namespace TestWEB_API.Controllers
    {
      public class ValuesController : ApiController
      {
        // GET api/values
        public string Get()
        {
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                if (session["Time"] == null)
                    session["Time"] = DateTime.Now;
                return "Session Time: " + session["Time"];
            }
            return "Session is not working";
        }// End Get()
        ...
      }//End Class()
    }//End Namespace
