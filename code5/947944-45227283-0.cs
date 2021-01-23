    public static class BinaryExt
    {
    	public static string ToBinary(this int number, int bitsLength = 32)
    	{
    		return NumberToBinary(number, bitsLength);
    	}
    	
    	public static string NumberToBinary(int number, int bitsLength = 32)
    	{
    		var result = Convert.ToString(number, 2).PadLeft(bitsLength, '0');
    		
    		return result;
    	}
    }
