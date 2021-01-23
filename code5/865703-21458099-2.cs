    private static void GetNext10FireTimes(ITrigger trigger)
    {
        Console.WriteLine("List of next 10 schedules: ");
    
        var dt = trigger.GetNextFireTimeUtc();
    
        for (int i = 0; i < 10; i++)
        {
    	if (dt == null)
    	    break;
    
    	Console.WriteLine(dt.Value.ToLocalTime());
    
    	dt = trigger.GetFireTimeAfter(dt);
        }
    }
