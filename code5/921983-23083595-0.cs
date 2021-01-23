    // omitted error-/equality checking for brevity
    public sealed class TimeType
    {
    	private static Dictionary<string, TimeType> _dic = new Dictionary<string, TimeType>();
    
        public static TimeType DAY   = new TimeType("Day", DateTimeIntervalType.Days);
        public static TimeType WEEK  = new TimeType("week", DateTimeIntervalType.Weeks);
        public static TimeType MONTH = new TimeType("month", DateTimeIntervalType.Months);
        public static TimeType YEAR  = new TimeType("year", DateTimeIntervalType.Years);
    	
    	public string Name { get; private set; }
    	public DateTimeIntervalType Type { get; private set; }
    			
    	private TimeType(string name, DateTimeIntervalType type)
    	{
    		Name = name;
    		Type = type;
    		_dic[name] = this;
    	}
    	
    	public static TimeType GetByName(string name)
    	{
    		return _dic[name];
    	}
    	public static IEnumerable<TimeType> All()
    	{
    	    return _dic.Values;
    	}
    }
