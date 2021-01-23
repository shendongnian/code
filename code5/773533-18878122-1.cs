    public ActionResult AddEntry(string ip, int TypeId, string returnUrl)
    {
         // Do some stuff
         string url = this.Request.UrlReferrer.AbsolutePath;
         return Redirect(url);
    }
