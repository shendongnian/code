    public Type PossibleActivitiesByDay(DayEnum day)
    {
        switch (day)
        {
            case DayEnum.Monday:
                return typeof(MondayActivities) ;
            case DayEnum.Tuesday:
                return typeof(TuesdayActivities) ;
            ...
        }
    }
