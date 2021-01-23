    DateTimePicker dtBDay = new DateTimePicker();
    dtBDay.Value = DateTime.Now.AddYears(-5);
    DateTimePicker dtJoin = new DateTimePicker();
    dtJoin.Value = DateTime.Now;
    if (dtBDay.Value >= dtJoin.Value)
    {
        throw new Exception("Date of Join cannot be less than or equal to Date of Birth");
    }
