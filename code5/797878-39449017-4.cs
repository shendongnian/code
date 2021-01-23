    public class DefaultController : Controller
    {
      protected IUnitOfWork UoW;
      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        UoW = new UnitOfWork(new MyDatabase());
      }
      protected override void OnActionExecuted(ActionExecutedContext filterContext) 
      {
        UoW.SaveChanges();
      }
    }
