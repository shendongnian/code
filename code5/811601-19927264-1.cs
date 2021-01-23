    if (_publicHolidayRepository != null)
    {
        var holidays = _publicHolidayFunc(allocation.StartDate.Year, allocation.User.CountryId);
        if (_holidays.Count() > 0)
        {
            ...
