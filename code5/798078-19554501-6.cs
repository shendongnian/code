    [AllowAnonymous]
    [ChildActionOnly]
    public ActionResult ExternalLoginsList(string returnUrl, string isRegistering) {
       ViewBag.IsRegistering = (isRegistering.ToLower() == "true");
       ViewBag.ReturnUrl = returnUrl;
       return (ActionResult)PartialView("_ExternalLoginsListPartial", new List<AuthenticationDescription>(AuthenticationManager.GetExternalAuthenticationTypes()));
    }
