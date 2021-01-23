        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class CheckUserPermissionsAttribute : ActionFilterAttribute
        {            
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                Repository repository = new Repository(); //create the repository here
                if (!repository.can(ADusername,Model,Action)) 
                {
        ...
