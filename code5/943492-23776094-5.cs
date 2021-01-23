    public ActionResult Time()
    {
        TimesheetModel model = new TimesheetModel();
        model.Activities = ... // get activities here
        return View(model);
    }
