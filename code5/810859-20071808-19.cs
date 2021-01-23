    public class WatchController : ApiController
    {
         private readonly IWatch _watch;
        
         public WatchController(IWatch watch)
         {
             _watch = watch;
         }
               
         public string Get()
         {
             var message = string.Format("The current time on the server is: {0}", _watch.GetTime());
             return message;
         }
    }
