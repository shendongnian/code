    string[] roles;
    
    try
    {
        roles = Roles.GetRolesForUser();
    }
    catch(HttpException)
    {
        return RedirectToAction("Login", "Account");
    }
    
    if(roles == null) return RedirectToAction("Login", "Account");
    
    if(roles.Contains("Admin")
    {
        ViewBag.Message = "Click on a link to get started.";
    }
    else if (roles.Contains("Authorized"))
    {
        ViewBag.Message = "Click on Organizations or Interfaces to get started.";
    }
    else if (roles.Contains("Unauthorized"))
    {
        ViewBag.Message = "An administrator must activate your account before you can use this tool.";
    }
    else
    {
        return RedirectToAction("Login", "Account");
    }
    
    return View();
