    public class ArrayViewResult : PartialViewResult
    {
        public IEnumerable<string> Views;
    
        protected override ViewEngineResult FindView(ControllerContext context)
        {
            return base.FindView(context);
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (!Views.Any())
                throw new Exception("no view...");
    
    
            TextWriter writer = context.HttpContext.Response.Output;
    
            foreach(var view in Views)
            {
                this.ViewName = view;
                ViewEngineResult result = FindView(context);
    
                ViewContext viewContext = new ViewContext(context, result.View, ViewData, TempData, writer);
                result.View.Render(viewContext, writer);
    
                result.ViewEngine.ReleaseView(context, result.View);
            }
        }
    }
