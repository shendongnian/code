    Queue<Job> jobs;
    IEnumerable<Job> priorityJobs;
    
    void ProcessJobs()
    {
        while (true)
        {
            Job job = null;
    
            lock (jobs)
            {
                job = priorityJobs.FirstOrDefault(j => j.NotYetStarted);
    
                if (job == null)
                {
                    do
                    {
                        if (jobs.Count == 0)
                            return;
    
                        job = jobs.Dequeue();
                    } while (job.NotYetStarted);
                }
    
                job.NotYetStarted = false;
            }
    
            job.Execute();
        }
    }
