    interface ICanPerformAction
    {
        List<string> CanPerformAction(IEntity entity);
    }
    
    public class HomeController : Project.Web.Controllers.Base.Controller, ICanPerformAction
    {
       ...
    }
