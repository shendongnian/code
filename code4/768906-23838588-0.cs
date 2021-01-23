    public class NotificationFilter : ActionFilterAttribute
    {
        public int _id;
        public string _proccess;
        public Guid _uid; 
    
        public NotificationFilter(int id,string proccess)
        {
            _id= id;
            _proccess = proccess;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             var val = filterContext.ActionParameters["uid"];
    
            _uid = (Guid)val;
        }
    
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
             var uid = _uid;
    
             dosomething(id,name,uid)
        }
    }
