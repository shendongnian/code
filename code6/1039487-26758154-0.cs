    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		DateTime fileDate = new DateTime(2013, 5, 1);
    		DateTime fileDateNewer = new DateTime(2014, 1, 1);
    		
    		GetMonthDifference(fileDate);
    		GetMonthDifference(fileDateNewer);
    	}
    	
    	public static void GetMonthDifference(DateTime fileDate)
    	{
    		DateTime currentDate =  DateTime.Now;
    		DateTime eighteenMonthsAgo = currentDate.AddMonths(-18);
    		
    		if (eighteenMonthsAgo > fileDate)
    			Console.WriteLine("{0} is greater than or equal to 18 months ago", fileDate);
    		else
    			Console.WriteLine("{0} is less than 18 months ago", fileDate);
    	}
    }
