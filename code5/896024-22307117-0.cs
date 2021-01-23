    public DateTime AddDays( value )
    using System;
    class Class1
    {
    	static void Main()
    	{
    		DateTime today = DateTime.Now;
    		DateTime answer = today.AddDays(36);
            Console.WriteLine("Today: {0:dddd}", today);
            Console.WriteLine("36 days from today: {0:dddd}", answer);
    	}
    }
