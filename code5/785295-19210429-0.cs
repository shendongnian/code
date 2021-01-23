    var jobs = new List<dynamic>();
    for (int i = 0; i < 100; i++)
    {
        string newJob = "Job" + i;
        int numBytes = i;
        TimeSpan requiredTime = new TimeSpan(0,0,i);
        //holds all info
        var job = new { newJob, numBytes, requiredTime };
        jobs.Add(job);
    }
    jobs.RemoveAll(p => p.numBytes > 50);
