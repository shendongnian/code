    public class TableAuthorizeAttribute : AuthorizeAttribute
    {
        public enum TableAction
        { 
            Read,
            Create,
            Update,
            Delete
        }
        public TableAction Action { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //do custom authorizization using Action and getting TableEntryID 
            //from filterContext.HttpContext.Request.QueryString or
            //filterContext.HttpContext.Request.Form
        }
    }
