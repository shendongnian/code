      [HttpPost]
    [ActionName("MemberLogin")]
    public ActionResult MemberLoginPost(MemberLoginModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            if (Membership.ValidateUser(model.Username, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect("/extranet/");
                }
                else
                {
                    return Redirect("/extranet/");
                }
            }
            else
            {
                TempData["Status"] = "Invalid username or password";
                return RedirectToCurrentUmbracoPage();
            }
        }
        TempData["Status"] = "Invalid request";
        return RedirectToCurrentUmbracoPage();
    }
