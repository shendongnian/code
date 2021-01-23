    void Main()
    {
    	var now = DateTime.Now.ToString();
    	
    	foreach(var format in DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns()){
    		DateTime result;
    		if(DateTime.TryParseExact(now, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out result)){
    			Console.WriteLine(string.Format("The date is {0}, the format is: {1}", result, format));
    		}
    	}
    }
