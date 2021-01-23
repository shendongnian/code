    [AllowAnonymous]
    public virtual ActionResult WamLogin(string returnUrl, string id)
    {
        var accountId= Request.Headers["user"];
        .....
        return View(MVC.Account.Views.Login);
    }
