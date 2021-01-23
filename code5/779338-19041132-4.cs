    try
    {
        if(Roles.IsUserInRole("Admin"))
        {
            ViewBag.Message = "Click on a link to get started.";
        }
        else if(Roles.IsUserInRole("Authorized"))
        {
            ViewBag.Message = "Click on Organizations or Interfaces to get started.";
        }
        else if (Roles.IsUserInRole("Unauthorized"))
        {
            ViewBag.Message = "An administrator must activate your account before you can use this tool.";
        }
        else
        {
            return RedirectToAction("Login", "Account");
        }
    }
    catch(ArgumentNullException)
    {
        // No user is currently logged in
        return RedirectToAction("Login", "Account");
    }
    catch(HttpException)
    {
        // There is no current logged on user. Role membership cannot be verified.
        return RedirectToAction("Login", "Account");
    }
    
    return View();
        
