        EventsResource.ListRequest req = service.Events.List(calendarId);
        // Limit the calendar to today
        req.TimeMin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        req.TimeMax = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
        req.SingleEvents = true;
        var events = req.Execute().Items;
