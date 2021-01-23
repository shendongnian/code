    [AllowAnonymous]
    public virtual PartialViewResult LoginHeader()
    {
        var model = new LoginViewModel();
        if (WebSecurity.IsAuthenticated)
        {
            model.SuccessfullyLogged = true;
            MemberDto memberDto = _memberService.GetMemberById(WebSecurity.CurrentUserId);
            model.MemberType_Id = memberDto.MemberType_Id;
        }
        else
            model.SuccessfullyLogged = false;
        return PartialView(model);
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public virtual PartialViewResult LoginHeader(LoginViewModel model, string returnUrl)
    {
        if (ModelState.IsValid && WebSecurity.Login(model.Email, model.Password, persistCookie: model.RememberMe))
        {
            // The user is valid so it will be redirected based on the returnUrl. If null it will return to the Home-Page
            model.SuccessfullyLogged = true;
            model.Result = @HeelpResources.AccountLoginViewAutenticationValidMsg;
        }
        else
        {
            // Invalid credentials, so the user will have to try again
            model.SuccessfullyLogged = false;
            model.Result = @HeelpResources.AccountLoginViewAutenticationInvalidMsg;
        }
        return PartialView(model);
    }
