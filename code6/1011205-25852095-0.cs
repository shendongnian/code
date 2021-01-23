    public class LogAttribute : ActionFilterAttribute
    {
        private dbcAmerica db = new dbcAmerica();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int data = Convert.ToInt32(filterContext.Controller.TempData["id"]);
            var checkIn = db.OrderPurchaseDetails.Where(o => o.QtyTraslate > 0 && o.OrderPurchaseID == data).ToList();
            if (checkIn.Count() > 0)
            {                
                filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary 
                                   {
                                       { "action", "Edit" },
                                       { "controller", "OrderPurchase" },
                                       { "id", data},
                                   });
            }
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // ... log stuff after execution
        }
    }
