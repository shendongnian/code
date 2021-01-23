    [HttpPost]
    public ActionResult GetRoles(string UserName)
    {
    	if (!string.IsNullOrWhiteSpace(UserName))
    	{
    		ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
    		SelectList list = new SelectList(Roles.GetAllRoles());
    		ViewBag.Roles = list;
    	}
    	return View("......");
    }
