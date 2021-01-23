    public class MyFilter : ActionFilterAttribute
    {      
        private readonly IApiDescriptionGroupCollectionProvider descriptionProvider;
        public MyFilter(IApiDescriptionGroupCollectionProvider descriptionProvider) 
        {
            this.descriptionProvider = descriptionProvider;
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            // The convention groups all actions for a controller into a description group
            var actionGroups = descriptionProvider.ApiDescriptionGroups.Items;
            // All the actions in the controller are given by
            var apiDescription = actionGroup.First().Items;
            
            // A route template for this action is
            var routeTemplate = apiDescription.RelativePath
        }
    }
