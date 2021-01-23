    using System;
    
    
    public class Test
    {
    	public static void Main()
    	{
    		String outpt=MakeCurrency("-123456");
    		Console.WriteLine(outpt);
    			String outpt2=MakeCurrency("123456");
    		Console.WriteLine(outpt2);
    	}
    	public static string MakeCurrency(string variant)
    {
        String _denom = "R 0.00";
       
            if (variant != "")
            {
                decimal _decimal = Math.Round((Convert.ToDecimal(variant)), 2, MidpointRounding.AwayFromZero);
                if (_decimal >= 0)
                    _denom = "R " + string.Format("{0:#,###0.00}", _decimal);
                else
                    _denom = "-$ " + string.Format("{0:#,###0.00}", Math.Abs(_decimal));
    
            }
        
    
        return _denom;
    }
    }
