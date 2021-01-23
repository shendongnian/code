        var nextDateTime = trigger.GetNextFireTimeUtc();
        //get next 1000 fire times
        for (int i = 0; i < 1000; i++)
        {
           if (!nextDateTime.HasValue) break;
           Console.WriteLine(nextDateTime.Value.ToLocalTime()); 
           nextDateTime = trigger.GetFireTimeAfter(nextDateTime);
        }
