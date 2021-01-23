    public ActionResult MyAction()
    {
     HttpContextBase httpContext = new HttpContextWrapper(HttpContext.Current);
     Uri uri = httpContext.Request.Url;
     ViewBag.MyUrl= UrlHelper.GenerateContentUrl(imageSource, httpContext);
     return View();
    }
