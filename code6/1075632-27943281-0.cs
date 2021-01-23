    public ActionResult Invalidate(string key)
    {
        if (key == ConfigurationManager.AppSettings["ApplicationSecurityKey"])
        {
            _cacheService.Invalidate();
            return Content("ok");
        }
        return null;
    }
