     public class CommandAction
     {
       public Action DoSomthing { get; set; }
       public ActionResult Result { get; set; }
    
       public CommandAction(Action action, ActionResult actionResult)
       {
          DoSomthing = action;
          Result = actionResult;
       }            
     }
    public class SomeController : Controller
    {       
      public Dictionary<string, CommandAction> commandHandler
      {
        get
        {
          return new Dictionary<string, CommandAction>()
          {
            {"foo",    new CommandAction( DoSomthing, View("foo"))},
            {"foo",    new CommandAction( DoSomthingElse, RedirectToAction("someAction"))},
            {"fooBar", new CommandAction( SomeMethod, File("file.txt", "application"))}  
          };
        }
        
        }
