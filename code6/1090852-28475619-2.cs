    public class JobObject : IEqualityComparer<JobObject>
    {
        public string Name { get; set; }
    
        public string Date { get; set; }
    
        //Other properties
        public bool Equals(JobObject x, JobObject y)
        {
             return x.Name == y.Name &&
                    x.Date == y.Date;
        }
    
        public int GetHashCode(JobObject job)
        {
            return job.GetHashCode();
        }
    
        // Then use it as follows.
        // JobObject newJob = CreateJob();
        // var existingJob = jobsArray.Find(x => x.Equals(newJob));
        // if(existingJob != null)
        // { 
              // Job Exists
        // }
    }
