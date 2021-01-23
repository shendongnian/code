        public ActionResult MyAction()
        {
            try
            {
                ...
            }
            catch
            {
                ControllerContext.RequestContext.HttpContext.Response.StatusCode = 500;
                ControllerContext.RequestContext.HttpContext.Response.StatusDescription = "My error message here";
                return null;
            }
        }
