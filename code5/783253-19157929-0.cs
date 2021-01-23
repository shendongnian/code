    private Job job;
    
    private static object jobInstanceLock;
    public string State 
    {
        get
        {
            return job.State;
        }
        set
        {
            lock (jobInstanceLock)
            {
                using (MyEntities context = new MyEntities())
                {
                    context.Jobs.Attach(job);
                    job.State = value;
    
                    context.SaveChanges();
                }
            }
        }
    }
