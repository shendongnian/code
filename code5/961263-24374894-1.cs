    //Entry point of every job
    public void Execute(IJobExecutionContext context)
    {
        Scheduler = context.Scheduler;
    
        JobCollection jobs = LoadJobs(context.JobDetail.JobDataMap["ConnectionString"].ToString());
        JobsWithTriggers jobTriggers = CreateTriggers(jobs);
        SchedulerJob(jobTriggers);
    }
    //You can use ADO.NET or an ORM here to load job information from the the table
    //and push it into a class. 
    protected JobCollection LoadJobs(string connectionString);
    //In this class you can create JobDetails and ITriggers for each job
    //and push them into a custom class
    protected JobsWithTriggers CreateTriggers(jobs);
    
    //Finally here you can schedule the jobs
    protected void ScheduleJobs(jobstriggers)
  
