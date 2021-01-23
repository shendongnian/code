    public List<Task<Job>> StartAllJobs()
    {
        if (CanExecuteJobs == false) return;
        var jobs = GetAllTypesImplementingInterface(typeof(Job)); // get all job implementations of this assembly.
        
        return jobs.Where(IsRealClass)
                    .Select(job => (Job)Activator.CreateInstance(job))
                    .Select(job => Task.Factory.StartNew(() => { job.ExecuteJob(); return job; }))
                    .ToList();        
    }
