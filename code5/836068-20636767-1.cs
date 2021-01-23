    if (dateAttempt == null && timeAttempt == null)
    {
        dateAttempt = GetA<DateTime>(bindingContext, "Value.Date");
        timeAttempt = GetA<DateTime>(bindingContext, "Value.TimeOfDay");
    }
