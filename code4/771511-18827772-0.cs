    if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
    {
        DateTime lastWeekSaturday = DateTime.Now.AddDays((int)DayOfWeek.Saturday - 1 - 7);
        DateTime lastWeekThursday = DateTime.Now.AddDays((int)DayOfWeek.Thursday - 1 - 7);
        DateTime lastWeekTuesday = DateTime.Now.AddDays((int)DayOfWeek.Tuesday - 1 - 7);
        DateTime thisWeekFriday = DateTime.Now.AddDays((int)DayOfWeek.Friday - 1);
        DateTime thisWeekThursday = DateTime.Now.AddDays((int)DayOfWeek.Thursday - 1);
        DateTime thisWeekTuesday = DateTime.Now.AddDays((int)DayOfWeek.Tuesday - 1);
        DateTime nextWeekTuesday = DateTime.Now.AddDays((int)DayOfWeek.Tuesday - 1 + 7);
    }
    else
        MessageBox.Show("Its not monday");
