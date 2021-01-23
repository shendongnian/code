    public static String Pack(String input)
    {
    	input = input.Replace("-", " ");
    	byte[] hashBytes = new byte[input.Length / 2];
    	for (int i = 0; i < hashBytes.Length; i++)
    	{
    		hashBytes[i] = Convert.ToByte(input.Substring(i * 2, 2), 16);
    	}
	    return Encoding.UTF7.GetString(hashBytes); // for perl/php
    }
