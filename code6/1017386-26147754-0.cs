    // Execute the job
    try
    {
       if (log.IsDebugEnabled)
       {
       		log.Debug("Calling Execute on job " + jobDetail.Key);
       }
				job.Execute(jec);
        endTime = SystemTime.UtcNow();
    }
    catch (JobExecutionException jee)
    {
    	endTime = SystemTime.UtcNow();
      jobExEx = jee;
      log.Info(string.Format(CultureInfo.InvariantCulture, "Job {0} threw a JobExecutionException: ", jobDetail.Key), jobExEx);
    }
    catch (Exception e)
    {
        endTime = SystemTime.UtcNow();
        log.Error(string.Format(CultureInfo.InvariantCulture, "Job {0} threw an unhandled Exception: ", jobDetail.Key), e);
        SchedulerException se = new SchedulerException("Job threw an unhandled exception.", e);
        qs.NotifySchedulerListenersError(
            string.Format(CultureInfo.InvariantCulture, "Job ({0} threw an exception.", jec.JobDetail.Key), se);
        jobExEx = new JobExecutionException(se, false);
    }
    jec.JobRunTime = endTime - startTime;
		
    // notify all job listeners
	if (!NotifyJobListenersComplete(jec, jobExEx))
	{
	    break;
	}
	instCode = SchedulerInstruction.NoInstruction;
	// update the trigger
	try
	{
	    instCode = trigger.ExecutionComplete(jec, jobExEx);
		if (log.IsDebugEnabled)
		{
	        log.Debug(string.Format(CultureInfo.InvariantCulture, "Trigger instruction : {0}", instCode));
		 }
    }
    catch (Exception e)
    {
        // If this happens, there's a bug in the trigger...
        SchedulerException se = new SchedulerException("Trigger threw an unhandled exception.", e);
        qs.NotifySchedulerListenersError("Please report this error to the Quartz developers.", se);
     }
