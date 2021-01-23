    DateTime? dateAttempt = GetA<DateTime>(bindingContext, "Date");
    DateTime? timeAttempt = GetA<DateTime>(bindingContext, "TimeOfDay");
    
    if (dateAttempt == null && timeAttempt == null)
    {
        dateAttempt = GetA<DateTime>(bindingContext, "Value.Date");
        timeAttempt = GetA<DateTime>(bindingContext, "Value.TimeOfDay");
    }
