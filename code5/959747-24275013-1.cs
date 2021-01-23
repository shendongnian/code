    string data = "flight 4057 in"; //I am guessing, this is what the original string will be.
    public string getFlightNumber(string data)
    {
    
    int flightNumLength = 4;// Or however long the string would be
    for(int index = 0; index < data.length(); index++)
    {
       if(index+flightNumLength + index < data.length())  
       {
           string TempFlight = data.subSting(index, flightNumLength);
        if(isNumeric(TempFlight))
        {
             return TempFlight;
        }
    
       }
    }
    }
    public static bool IsNumeric(object Expression){
        bool isNum;
        double retNum;
	
        isNum = Double.TryParse(Convert.ToString(Expression),     System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo, out retNum );
        return isNum; 
    }
