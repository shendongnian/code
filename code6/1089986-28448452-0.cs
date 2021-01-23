    using (var connection = JobStorage.Current.GetConnection())
    {
       var recurring = connection.GetRecurringJobs().FirstOrDefault(p => p.Id == "AccountMonthlyActionExtendPaymentSubscription");
    
       if (recurring == null)
       {
           // recurring job not found
           Console.WriteLine("Job has not been created yet.");
       }
       else if (!recurring.NextExecution.HasValue)
       {
           // server has not had a chance yet to schedule the job's next execution time, I think.
           Console.WriteLine("Job has not been scheduled yet. Check again later.");
       }
       else
       {
           Console.WriteLine("Job is scheduled to execute at {0}.", recurring.NextExecution);
       }
    }
