    public class JobObject
    {
        public string Name { get; set; }
    
        public string Date { get; set; }
        //Other properties
    }
    
    public class JobObjectComparer : IEqualityComparer<JobObject>
    {        
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
        // var comparer = new JobObjectComparer();
        // var existingJob = jobsArray.Find(x => comparer.Equals(x, newJob));        
        // if(existingJob != null)
        // { 
        //   Job Exists
        // }
    }
