    class Job
    {
        public int ID { get; set; }
        public DateTime? LastRun { get; set; }
        public int Frequency { get; set; }
        public bool InProgress { get; set; }
    }
    
    List<Job> JobList = new List<Job>();
    
    // Every 2 minutes (or whatever).
    void timerMain_Tick()
    {
        foreach (RepModel repModelo in listaRep)
        {
            if(!JobList.Any(x => x.ID == repModelo.ID)
            {
                JobList.Add(new Job(){ ID = repModel.ID, Frequency = 120 });
            }
        }
    }
    
    // Every 10 seconds (or whatever).
    void timerTask_Tick()
    {
        foreach(var job in JobList.Where(x => !x.InProgress && (x.LastRun == null || DateTime.Compare(x.LastRun.AddSeconds(x.Duration), DateTime.Now) < 0))
        {
            Task t = new Task(() => { 
                // Do task.
            }).ContinueWith(() => {
                job.LastRun = DateTime.Now;
                job.InProgress = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());;
            job.InProgress = true;
            t.Start();
        }
    }
