        ITrigger newTrigger = TriggerBuilder.Create()
                             .WithCronSchedule(newExpression)
                             .WithIdentity(newTriggerKey)
                             .StartNow()
                             .Build();
        sched.RescheduleJob(existingTrigger.Key, newTrigger);
