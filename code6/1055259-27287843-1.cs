    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(LoginAccountInfoModel accountInfoModel, string returnUrl)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (accountInfoModel.Email.Contains("@somecompanydomain.com"))
                {
                    _webLoginService = (IWebLoginService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(WebAdminLoginService));
                }
