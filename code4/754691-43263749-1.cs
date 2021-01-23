    foreach (var oldTrigger in scheduler.GetTriggers(new JobKey(jobName)))
    {
        // clone the old trigger with new group name
        var newTrigger = oldTrigger.GetTriggerBuilder()
            .WithIdentity(oldTrigger.Key.Name) // uses default trigger group name
            .Build();
        
        // not a typo, the method to reschedule a trigger is called "RescheduleJob" for some reason
        scheduler.RescheduleJob(oldTrigger.Key, newTrigger);
    }
