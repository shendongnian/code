    [HttpPost]
    public ActionResult Time(TimesheetModel model)
    {
        foreach (var activity in model.Activities)
        {
            // pass activity.Hours to database here
        }
    }
