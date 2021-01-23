    public JsonResult IsEmailAvailable(string Email)
    {
      if(EmailNotAvailable)
      {
        return Json(false, JsonRequestBehavior.AllowGet);
        // or to override the error message you defined in the RemoteAttribute
        return Json("Another custom message, JsonRequestBehavior.AllowGet);
      }
      else
      {
        return Json(true, JsonRequestBehavior.AllowGet);
      }
    }
