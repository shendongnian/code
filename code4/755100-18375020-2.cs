    DateTime monday = mcCalendar.SelectionEnd.StartOfWeek(DayOfWeek.Monday);
    List<int> days = new List<int>();
    for (int i = 0; i < 6; i++)
    {
        days.Add(monday.AddDays(i).Day);
    }
