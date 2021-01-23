    private void IdentifyDay(List<CallDays> callDayList)
    {
        // Some condition to set DayOFWeek filter criteria
    
        DayOfWeek dayOfWeekToFind = drInMemory.Start.DayOfWeek;
    
        foreach (var item in callDayList)
        {
            if (item.DayOWList.Contains(dayOfWeekToFind))
            {
                // do something
            }
        }
    }
