        public ActionResult Index()
        {
            var previousPage = System.Web.HttpContext.Current.Request.UrlReferrer;
            
            //Yourlogic
            RedirectToAction(previousPage);
        }
