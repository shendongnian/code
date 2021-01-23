    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class DateTimeRange
    {
        public DateTimeRange(DateTime startDate, DateTime endDate)
        {
            if (!startDate.Day.Equals(endDate.Day))
                throw new Exception("The start and end days are not equal.");
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }    
    public class Program
    {
    	static List<DateTimeRange> availableTimes = new List<DateTimeRange>()
        {
            new DateTimeRange(new DateTime(2015, 3, 16, 08, 00, 00), new DateTime(2015, 3, 16, 10, 00, 00)),
            new DateTimeRange(new DateTime(2015, 3, 16, 12, 00, 00), new DateTime(2015, 3, 16, 14, 00, 00)),
            new DateTimeRange(new DateTime(2015, 3, 16, 15, 00, 00), new DateTime(2015, 3, 16, 16, 00, 00)),
        };
    
	    private static IEnumerable<DateTimeRange> GetBlockedTimes(IEnumerable<DateTimeRange> ranges)
    	{
	    	var min = ranges.Select(r => r.StartDate).Min().Date;
    		var max = ranges.Select(r => r.EndDate).Max().AddDays(1).Date.AddTicks(-1);
		
	    	foreach(var range in ranges.OrderBy(r => r.StartDate))
    		{
    			yield return new DateTimeRange(min, range.StartDate);
    			min = range.EndDate;
    		}
		
	    	yield return new DateTimeRange(min, max);
    	}
	
    	public static void Main()
    	{
    		foreach(var item in GetBlockedTimes(availableTimes))
    		{
    			Console.WriteLine(item.StartDate + " - " + item.EndDate);
    		}
    	}
    }
