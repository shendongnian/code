    // "01.13 " or "01.13". Standard formatting applied: $123.45
    // "01.315" or "01.31½". Standard formatting applied: $123.45
    public class Test
    {
    	void Main()
    	{
    		decimal number1 = 1.13M;
    		decimal number2 = 1.315M;
    
    		string output1 = String.Format(new CustomNumberFormat(),
    								 "\"{0:G}\" or \"{0:S}\". Standard formatting applied: {1:C2}",
    								 number1, 123.45);
    		Console.WriteLine(output1);
    
    		string output2 = String.Format(new CustomNumberFormat(),
    								 "\"{0:G}\" or \"{0:S}\". Standard formatting applied: {1:C2}",
    								 number2, 123.45);
    		Console.WriteLine(output2);
    	}
    }
    
    public class CustomNumberFormat : System.IFormatProvider, System.ICustomFormatter
    {
    	public object GetFormat(Type formatType)
    	{
    		if (formatType == typeof(ICustomFormatter))
    			return this;
    		else
    			return null;
    	}
    
    	public string Format(string fmt, object arg, System.IFormatProvider formatProvider)
    	{
    		// Provide default formatting if arg is not a decimal. 
    		if (arg.GetType() != typeof(decimal))
    			try
    			{
    				return HandleOtherFormats(fmt, arg);
    			}
    			catch (FormatException e)
    			{
    				throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
    			}
    
    		// Provide default formatting for unsupported format strings. 
    		string ufmt = fmt.ToUpper(System.Globalization.CultureInfo.InvariantCulture);
    		if (!(ufmt == "G" || ufmt == "S"))
    			try
    			{
    				return HandleOtherFormats(fmt, arg);
    			}
    			catch (FormatException e)
    			{
    				throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
    			}
    
    		// Convert argument to a string. 
    		string result = ((decimal)arg).ToString("0#.000");
    
    		if (ufmt == "G")
    		{
    			var lastFormattedChar = result[result.Length - 1];
    			switch (lastFormattedChar)
    			{
    				case '0':
    					result = result.Substring(0, result.Length - 1) + " ";
    					break;
    			}
    
    			return result;
    		}
    		else if (ufmt == "S")
    		{
    			var lastFormattedChar = result[result.Length - 1];
    			switch (lastFormattedChar)
    			{
    				case '0':
    					result = result.Substring(0, result.Length - 1);
    					break;
    				case '5':
    					result = result.Substring(0, result.Length - 1) + "½";
    					break;
    			}
    
    			return result;
    		}
    		else
    		{
    			return result;
    		}
    	}
    
    	private string HandleOtherFormats(string format, object arg)
    	{
    		if (arg is System.IFormattable)
    			return ((System.IFormattable)arg).ToString(format, System.Globalization.CultureInfo.CurrentCulture);
    		else if (arg != null)
    			return arg.ToString();
    		else
    			return String.Empty;
    	}
    }
