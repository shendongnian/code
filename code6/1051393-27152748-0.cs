    public enum DayEnum{Monday,Tuesday}
    public enum MondayActivities { Washing, Ironing }
    public enum TuesdayActivities { Cleaning, Hoovering }
    
    public static Array PossibleActivitiesByDay(DayEnum day)
    {
        switch (day)
        {
            case DayEnum.Monday:
                return Enum.GetValues(typeof(MondayActivities)) ;
            case DayEnum.Tuesday:
                return Enum.GetValues(typeof(TuesdayActivities )) ;
        }
        return null;
     }
