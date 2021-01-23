    public class TitleAttribute : ActionFilterAttribute
        {
            protected string description;
    
            public TitleAttribute(String descritionIn)
            {
                this.description = descritionIn;
            }
    
            public String Description
            {
                get
                {
                    return this.description;
                }
            }
    
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.Controller.ViewBag.Title = description;
            }
        }
