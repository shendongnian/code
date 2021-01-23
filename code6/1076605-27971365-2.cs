    public delegate string del_t(double input);
    	
    public static del_t makeConverter(string toUnit, double factor, double offset = 0.0)
    {
        return delegate(double input) 
    	{
    		return string.Format("{0:0.##} {1}", (offset + input) * factor, toUnit );
    	};
    }
    	
    public static void Main()
    {
    	var milesToKm = makeConverter("km", 1.60936);
    	var poundsToKg = makeConverter("kg", 0.45460);
    	var farenheitToCelsius = makeConverter("degrees C", 0.5556, -32);
     		
    	Console.WriteLine("{0}", milesToKm(10) );
    	Console.WriteLine("{0}", poundsToKg(2.5) );
    	Console.WriteLine("{0}", farenheitToCelsius(98));
    }
