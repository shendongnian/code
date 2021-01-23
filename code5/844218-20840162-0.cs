    bool IsDefaultTime(string parseTime)
    {
        DateTime date;
        //parse the date and see if we have a time element
        if(DateTime.TryParse(parseTime, out date))
        {
            //returns true when the time is midnight.
            return date.TimeOfDay == TimeSpan.Zero;
        }
	    throw new ArgumentException(string.Format("Value was not in recognized datetime     format: {0}", parseTime));
    }
