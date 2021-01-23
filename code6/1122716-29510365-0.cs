    var allTriggerKeys = sched.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup());
    foreach (var triggerKey in allTriggerKeys)
    {
        ITrigger trigger = sched.GetTrigger(triggerKey);
        if(trigger.JobName=="yourtriggername", trigger.JobGroup=="yourjobgroupname")
           {
                scheduler.RescheduleJob(trigger.JobName, trigger.JobGroup, trigger);
           }
    } 
