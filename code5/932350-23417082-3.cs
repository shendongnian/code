    public ActionResult Events()
    {
        var events = HobbsEventsMobile.Models.Event.GetEventSummary();
        return Json(events, JsonRequestBehavior.AllowGet);
    }
