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
