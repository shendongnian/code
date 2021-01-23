    public ActionResult Widget()
    {
        var eventIds = ViewEventPropertyService.Get()
            .Select(y => new EventDetailsViewModel { EventId = y.EventId })
            .ToList();
        return PartialView("Widget", eventIds);
    }
