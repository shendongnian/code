    public ActionResult Detail(int id)
    {
        if(MySecurityProvider.CanView(id, HttpContext.Current.User.Identity.Name){
            return View();
        }
        Return RedirectToAction("PermissionIssue", "Errors");
    }
