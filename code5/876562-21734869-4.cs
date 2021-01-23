    public class A_Controller : ApiController
    {
      [ActionName("Default")]
      [CustomAuthorize()]
      public string get()
      {
        return "Requested Data";
      }
    }
