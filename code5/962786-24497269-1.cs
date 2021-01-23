    DateTime dt;
    if (!DateTime.TryParse("07:35", out dt))
    {
        // handle validation error
    }
    TimeSpan time = dt.TimeOfDay;
