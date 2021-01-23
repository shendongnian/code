    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string dateTimeString = "21‎-‎10‎-‎2014‎ ‎15‎:‎40‎:‎30";
    		dateTimeString = Regex.Replace(dateTimeString, @"[^\u0000-\u007F]", string.Empty);
    		
    		string inputFormat = "dd-MM-yyyy HH:mm:ss";
    		string outputFormat = "yyyy-MM-dd HH:mm:ss";
    		var dateTime = DateTime.ParseExact(dateTimeString, inputFormat, CultureInfo.InvariantCulture);
    		string output = dateTime.ToString(outputFormat);
    		
    		Console.WriteLine(output);
    	}
    }
