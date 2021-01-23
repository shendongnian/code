    public bool LaterThan7Days(int valueFromClass)
    {
        DateTime myTime = //here convert valueFromClass to Datetime, search in google please
        TimeSpan t = new TimeSpan(7,0 , 0, 0); //days, hours ,mins, seconds
        DateTime timeToCompare = myTime + t;
        return timeToCompare > DateTime.Now;
    }
