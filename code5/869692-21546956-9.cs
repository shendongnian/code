    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		decimal dec = -12345678912345678912345678912.456m;
    		int digits = GetDigits(dec);
    		Console.WriteLine(digits.ToString());
    	}
    	
    	static int GetDigits(decimal dec)
    	{
    		decimal d = decimal.Floor(dec < 0 ? decimal.Negate(dec) : dec);
            // As stated in the comments of the question, 
            // 0.xyz should return 0, therefore a special case
            if (d == 0m)
                return 0;
    		int cnt = 1;
    		while ((d = decimal.Floor(d / 10m)) != 0m)
    		    cnt++;
    		return cnt;
    	}
    }
