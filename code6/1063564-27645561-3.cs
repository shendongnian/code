    public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
    
            OnTrackingAction(filterContext);
        }
    
    public virtual void OnTrackingAction(ActionExecutingContext filterContext)
        {
            var context = filterContext.RequestContext.HttpContext;
    
            var track = new OurWebTrack(context);
    
            trackingService.Track(track);
        }
