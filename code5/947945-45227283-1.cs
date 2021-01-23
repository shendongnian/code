    public static class BinaryExt
    {
    	public static string ToBinary(this int number, int bitsLength = 32)
    	{
    		return NumberToBinary(number, bitsLength);
    	}
    	
    	public static string NumberToBinary(int number, int bitsLength = 32)
    	{
    		string result = Convert.ToString(number, 2).PadLeft(bitsLength, '0');
    		
    		return result;
    	}
	
		public static int FromBinaryToInt(this string binary)
		{	
			return BinaryToInt(binary);
		}
		
		public static int BinaryToInt(string binary)
		{	
			return Convert.ToInt32(binary, 2);
		}	
    }
