    private decimal GetValue(string text)
	{
	    decimal result = 0;
	    if (!string.IsNullOrWhiteSpace(text))
	    {
	        if (decimal.TryParse(text, out result))
	        {
	            return result;
	        }
	        else
	        {
	            throw new Exception("Invalid value");
	        }
	    }
	    return result;
	}
