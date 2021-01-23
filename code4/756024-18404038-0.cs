    public static Int16? ToInt16(string value)
    {
    	double rDouble;
    	if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out rDouble))
    	{
    		// log: not a valid number
    		return null;
    	}
    	if (rDouble < Int16.MinValue)
    	{
    		// log: too small
    		return Int16.MinValue;
    	}
    	if (rDouble > Int16.MaxValue)
    	{
    		// log: too big
    		return Int16.MaxValue;
    	}
    
    	var rounded = Math.Round(rDouble, MidpointRounding.AwayFromZero);
    
    	return (Int16)rounded;
    }
