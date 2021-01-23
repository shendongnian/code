    public class MyController : Controller
    {
     public MyController(IRepository repository)
     {
      // mvc cannot easily instantiate this controller 
      // unless it knows how to inject a concrete implementation
      // of the IRepository interface
     }
    }
