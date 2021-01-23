    if (User.IsInRole("Admin))
    {
        return View("AdminView", model);
    }
    else
    {
        return View("UserView", model);
    }
