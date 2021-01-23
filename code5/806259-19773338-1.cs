    using System;
    using System.Collections.Generic;
    
    public class MyClass
    {
    	public static void RunSnippet()
    	{
     		LocalizedDateTime dt = LocalizedDateTime.FromUtc(DateTime.UtcNow);
    		Console.WriteLine(dt.LocalDateTime.ToString("dd/MM/yyyy hhmmss"));
    		Console.WriteLine(dt.UtcDateTime.ToString("dd/MM/yyyy hhmmss"));
    	}
    	
    	#region Helper methods
    	
    	public static void Main()
    	{
    		try
    		{
    			RunSnippet();
    		}
    		catch (Exception e)
    		{
    			string error = string.Format("---\nThe following error occurred while executing the snippet:\n{0}\n---", e.ToString());
    			Console.WriteLine(error);
    		}
    		finally
    		{
    			Console.Write("Press any key to continue...");
    			Console.ReadKey();
    		}
    	}
    
    	private static void WL(object text, params object[] args)
    	{
    		Console.WriteLine(text.ToString(), args);	
    	}
    	
    	private static void RL()
    	{
    		Console.ReadLine();	
    	}
    	
    	private static void Break() 
    	{
    		System.Diagnostics.Debugger.Break();
    	}
    
    	#endregion
    }
    
    public class LocalizedDateTime
    {
        private LocalizedDateTime(DateTime localDateTime)
        {
    		LocalDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
        }
    
        public DateTime UtcDateTime{
    		get{
    			return LocalDateTime.ToUniversalTime();
    		}
    	}
    	
        public DateTime LocalDateTime{get; private set;}
       
        public static LocalizedDateTime FromLocal(DateTime localDateTime)
        {
            return new LocalizedDateTime(localDateTime);
        }
    
        public static LocalizedDateTime FromUtc(DateTime utcDateTime)
        {
            return new LocalizedDateTime(TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TimeZoneInfo.Local));
        }
    }
