    public JsonResult UsernameUnique(string userName)
    {
        /// Checking your validation
        return Json(false, JsonRequestBehavior.AllowGet);
    }
