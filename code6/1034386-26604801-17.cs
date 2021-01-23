    private void GetNextXFireTimes(ITrigger trigger, int counts)
    {
    	var dt = trigger.GetNextFireTimeUtc();
    	for (int i = 0; i < (counts-1); i++)
    	{
    		if (dt == null)
    		{
    			break;
    		}
    	Console.WriteLine(dt.Value.ToLocalTime());
    	dt = trigger.GetFireTimeAfter(dt);
        }
    }
