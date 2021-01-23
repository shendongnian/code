    public class BaseController : Controller
    {
        protected int promotionId = 0;
    
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool thereIsPromo = false;
            
            // Check if the request has the paramter PromotionId
            if (Request.Params.AllKeys.Contains("promotionId"))
            {
                promotionId = int.Parse(Request["promotionId"]);
                thereIsPromo = true;
            }
    
            var foo = filterContext.RouteData;
            // TODO: use the foo route value to perform some action
    
            base.OnActionExecuting(filterContext);
        }
    
    }
