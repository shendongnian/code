    private string Do(Day day)
    {
        switch (day)
        {
            case Day.Monday:
            case Day.Wednesday:
            case Day.Friday:
                return "Study";
            case Day.Tuesday:
            case Day.Thursday:
                return "Play Futbol";
            default:
                return "Party";
        }
    }
