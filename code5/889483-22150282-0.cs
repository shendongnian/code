    public ActionResult DoesUserNameExist(string username)
    {
        if (Exists(uasername))
        {
            string errorMessage = "Some dynamic error message";
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
    
        return Json(true, JsonRequestBehavior.AllowGet);
    }
