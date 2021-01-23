    public JsonResult Getjsondata()
    {
        var Contacts = db.Contacts.ToList();
        return Json(Contacts, JsonRequestBehavior.AllowGet);
    }
