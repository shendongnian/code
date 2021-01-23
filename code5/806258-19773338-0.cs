    public class LocalizedDateTime
    {
    	private LocalizedDateTime(DateTime utcDateTime)
    	{
    		UtcDateTime = utcDateTime;
    	}
    	
    	public DateTime UtcDateTime{get; private set;}
    	public DateTime LocalDateTime
    	{
    		get{
    			return DateTime.SpecifyKind(UtcDateTime, DateTimeKind.Local);
    		}
    	}
    	
    	public static LocalizedDateTime FromLocal(DateTime localDateTime)
    	{
    		return new LocalizedDateTime(localDateTime.ToUniversalTime());
    	}
    	
    	public static LocalizedDateTime FromUtc(DateTime utcDateTime)
    	{
    		return new LocalizedDateTime(utcDateTime);
    	}
    }
