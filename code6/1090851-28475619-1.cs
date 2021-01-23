    public List<JobObject> PendingJobsArray = new List<JobObject>();
    public List<JobObject> ActiveJobsArray = new List<JobObject>();
    public List<JobObject> CompletedJobsArray = new List<JobObject>();
    
    var jobName = xmlParser.getElementAttrValue(index, "Name");
    var pendingJob = Program.PendingJobsArray.Find(x=>x.jobObjectName == jobName)
    
    if(pendingJob == null)
    {
      // New job. Create the pending job here.
      var newJob = CreateJob();
      Program.PendingJobsArray.Add(newJob);
    }
    else
    {
      // Update the pending job here
    }
