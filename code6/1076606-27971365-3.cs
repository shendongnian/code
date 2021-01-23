    public static void Main()
    {
    	var milesToKm = new Converter("km", 1.60936);
    	var poundsToKg = new Converter("kg", 0.45460);
    	var farenheitToCelsius = new Converter("degrees C", 0.5556, -32);
    
    	Console.WriteLine("{0}", milesToKm.Convert(10) );
    	Console.WriteLine("{0}", poundsToKg.Convert(2.5) );
    	Console.WriteLine("{0}", farenheitToCelsius.Convert(98) );
    }
    
    class Converter
    {
    	string m_toUnit;
    	double m_factor;
    	double m_offset;
    	
    	public Converter(string toUnit, double factor, double offset = 0)
    	{
    		m_toUnit = toUnit;
    		m_factor = factor;
    		m_offset = offset;
    	}
    	
    	public string Convert(double input)
    	{
    		return string.Format("{0:0.##} {1}", (m_offset + input) * m_factor, m_toUnit );
    	}
    }
