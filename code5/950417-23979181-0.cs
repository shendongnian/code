    var user = _userManager.FindById(User.Identity.GetUserId());
                
    if (_userManager.IsInRole(user.Id, "Admin"))
    {
            //Do admin stuff
    }
