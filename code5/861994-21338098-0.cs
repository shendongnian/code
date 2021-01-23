    public JsonResult UserExists(string UserName) {
    
        var user = UserManager.FindByName(UserName);
        if (!db.AspNetUsers.Any(x => x.UserName == UserName))
        return Json(true, JsonRequestBehavior.AllowGet);
    
       return Json(string.Format("{0} is not available", UserName) , JsonRequestBehavior.AllowGet);
        
    }
