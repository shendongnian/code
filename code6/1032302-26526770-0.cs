    public static string convert(string dateValue){
    		string pattern = "MM/dd/yyyy";
    		DateTime parsedDate; 
    		if (DateTime.TryParseExact(dateValue, pattern, null, 
    		                           DateTimeStyles.None, out parsedDate)){
    			return String.Format("{0:yyyy-MM-dd}",parsedDate);
    		}
    		return null;
    	}
    	//usage example
    		string dateValue="10/10/2014";
    		string converted=convert(dateValue);
    		if(converted!=null){
    			Console.WriteLine("Converted '{0}' to {1}.", 
    				                  dateValue, converted); 
    		} 
