    public class TimeRangeRule : ValidationRule
    {
    	private TimeSpan _min;
    	private TimeSpan _max;
    
    	public TimeRangeRule()
    	{          
    	}
    
    	public TimeSpan Min
    	{
    		get { return _min; }
    		set { _min = value; }
    	}
    
    	public TimeSpan Max
    	{
    		get { return _max; }
    		set { _max = value; }
    	}
    
    	public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    	{
    		if (value != null)
    		{
    			TimeSpan time = (TimeSpan)value;
    						   
    			if ((time < Min) || (time > Max))
    			{
    				return new ValidationResult(false,
    				  "Please enter the time in the range: " + Min + " - " + Max + ".");
    			}
    			else
    			{
    				return new ValidationResult(true, null);
    			}
    		}
    		else
    			return new ValidationResult(true, null);
    	}
    }
