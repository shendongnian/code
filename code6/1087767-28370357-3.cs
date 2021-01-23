    [HttpPost]
    public ActionResult Index(ClubViewModel viewModel)
    {
        var monday = viewModel.MeetingDays[(int)DayOfWeek.Monday];
        var tuesday = viewModel.MeetingDays[(int)DayOfWeek.Tuesday];
        // etc etc
    
        return View();
    }
