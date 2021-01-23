    public class MyEvent
    {
    	public bool IsInsideSameMonth
    	{
    		get
    		{
    			return (StartDate.Year == EndDate.Year && StartDate.Month == EndDate.Month);
    		}
    	}
    	private string _EventTile;
    	public string EventTitle
    	{
    		get { return _EventTile; }
    
    		set
    		{
    			ValidateTitle(value); // this will throw if invalid and leave the value of _EventTitle unchanged
    			_EventTile = value;
    		}
    	}
    
    	private DateTime _StartDate  = DateTime.MinValue;;
    	public DateTime StartDate
    	{
    		get { return _StartDate; }
    		set
    		{
    			ValidateDates(value, EndDate); // this will throw if invalid and leave the value of _StartDate unchanged
    			_StartDate = value;
    
    		}
    	}
    
    	private DateTime _EndDate  = DateTime.MaxValue;;
    	public DateTime EndDate
    	{
    		get { return _EndDate; }
    		set
    		{
    			ValidateDates(StartDate, value); // this will throw if invalid and leave the value of _EndDate unchanged
    			_EndDate = value;
    		}
    	}
    
    	private void ValidateDates(DateTime start, DateTime end)
    	{
    		if (start > end)
    		{
    			throw new MyEventException("Start date is not supposed to be greater than end date.");
    		}
    	}
    
    	private void ValidateTitle(string title)
    	{
    		if (String.IsNullOrWhiteSpace(title))
    		{
    			throw new MyEventException("Title cannot be empty.");
    		}
    	}
    
    	public void Validate()
    	{
    		ValidateDates(StartDate, EndDate);
    		ValidateTitle(EventTitle);
    	}
    }
    
    public class MyEventException : Exception
    {
    	public MyEventException(string message)
    		: base(message)
    	{
    	}
    }
