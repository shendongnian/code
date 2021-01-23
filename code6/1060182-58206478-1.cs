		public virtual ActionResult Index()
        {
            return this.RedirectToAction(controller => controller.Test());
		}
	    public virtual ActionResult Test()
	    {
             ...
	    }
