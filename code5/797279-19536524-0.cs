        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          base.OnActionExecuting(filterContext);
          var controller = default(object);
          if (RouteData.Values.TryGetValue("controller", out controller))
          {
             ViewBag.Title = controller;
          }
       }
