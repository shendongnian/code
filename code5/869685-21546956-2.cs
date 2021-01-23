    using System;
    
    public class Test
    {
    	public static void Main()
    	{
            decimal dec = -123456789.456m;
            decimal d = decimal.Floor(dec < 0 ? decimal.Negate(dec) : dec);
            int cnt = 1;
            while ((d = decimal.Floor(d / 10m)) != 0)
                cnt++;
            Console.WriteLine(cnt.ToString());
    	}
    }
