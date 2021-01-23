    public class TimeClock
    {
	    public int EmployeeId { get; set; }	
        public int TimeClockId { get; set; }
	    public DateTime TimeStamp { get; set; }
    }
    public class Shift
    {
	    public TimeClock PunchIn { get; set; }
	    public TimeClock PunchOut { get; set; }
	    public int EmployeeId { get; set; }
	    public bool HasShiftEnded 
	    { 
		    get { return PunchIn != null && PunchOut != null; } 
	    }
	
	    public double? DurationInHours
	    {
		    get
		    {
			    if (HasShiftEnded)
				    return (PunchOut.TimeStamp - PunchIn.TimeStamp).TotalHours;
			
			    return null;
		    }
	    }
    }
