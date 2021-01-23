    public ActionResult Create(Job job)
    {
        if (job.TargetDateSurvey.Value < DateTime.Today)
        {
            ModelState.AddModelError("TargetDateSurvey", "Date must be today or later.");
        }
        if (ModelState.IsValid)
        ...
    }
