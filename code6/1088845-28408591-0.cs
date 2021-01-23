    public ActionResult CreateNew()
    {
    
        ClubViewModel viewModel = new ClubViewModel();
     
        viewModel.MeetingDays = new List<CalendarEntryViewModel>();
    
        viewModel.MeetingDays.Add(new CalendarEntryViewModel { Day = Days.Monday });
        viewModel.MeetingDays.Add(new CalendarEntryViewModel { Day = Days.Tuesday });
        viewModel.MeetingDays.Add(new CalendarEntryViewModel { Day = Days.Wednesday });
        viewModel.MeetingDays.Add(new CalendarEntryViewModel { Day = Days.Thursday });
        viewModel.MeetingDays.Add(new CalendarEntryViewModel { Day = Days.Friday });
        viewModel.MeetingDays.Add(new CalendarEntryViewModel { Day = Days.Saturday });
        viewModel.MeetingDays.Add(new CalendarEntryViewModel { Day = Days.Sunday });
    
        return View(viewModel);
    }
