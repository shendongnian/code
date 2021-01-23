    try
    {
        WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { UserEmail = model.UserEmail});
        WebSecurity.Login(model.UserName, model.Password);
        return RedirectToAction("Index", "Home");
    }
    catch (MembershipCreateUserException e)
    {
        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
    }
    catch (SqlException e)
    {
        if (e.Message.Contains("UK_UserEmail"))
        {
           ModelState.AddModelError("Error","Email cannot be duplicate");
        }
    }
