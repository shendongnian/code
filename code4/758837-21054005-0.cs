    public class RavenBaseController : Controller
    {
       public IDocumentSession RavenSession { get; protected set; }
       public RavenBaseController()
       {
          RavenSession = MvcApplication.Store.OpenSession("ravendbtesting");
       }
       protected override void OnActionExecuted(ActionExecutedContext filterContext)
       {
          if (filterContext.IsChildAction)
             return;
          using (RavenSession)
          {
             if (filterContext.Exception != null)
                 return;
    
             if (RavenSession != null)
                 RavenSession.SaveChanges();
          }
       }
    }
