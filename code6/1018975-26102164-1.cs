    public  void SchedulenewAlert()
        {
            try
            {
               SchedularHanlder schedHandler = new SchedularHanlder()
    
                String jobname = "remotelyAddedJob2" + DateTime.Now.Ticks.ToString();
                IJobDetail job = JobBuilder.Create<MyTest>()
                    .WithIdentity(jobname, "default1")
                    .Build();
    
                JobDataMap map = job.JobDataMap;
                map.Put("msg", "Your remotely added job has executed!");
    
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("remotelyAddedTrigger", "default")
                    .ForJob(job.Key)
                    .WithCronSchedule("/5 * * ? * *")
                    .Build();
    
          var TestTrigger =      TriggerBuilder.Create().ForJob(job).WithIdentity("remotelyAddedTrigger2", "default1")
                    .StartNow().Build();
    
    
    DateTimeOffset pullReportsToQueuejobCalendar = DateBuilder.DateOf(9, 30, 17, 1, 6, 2005);
    string trgName = "pullReportsFromQueuejobTrigger" + DateTime.Now.Ticks.ToString();
                var pullReportsToQueuejobTrigger = new CalendarIntervalTriggerImpl
                {
                    StartTimeUtc = pullReportsToQueuejobCalendar,
                    Name = trgName,
                    RepeatIntervalUnit = IntervalUnit.Second,
                    RepeatInterval = 40000    // every --- seconds
                };
                /// while (true)
                // {
    
    
                // schedule the job
                schedHandler.ScheduleJob(job, pullReportsToQueuejobTrigger);
    
            }
            catch (Exception ex)
            {
                string lines = "==================Exception  Client===========================\n" + DateTime.Now.TimeOfDay.ToString() + "\n====================END=========================\n";
    System.IO.StreamWriter file = new  System.IO.StreamWriter("c:\\ExceptionClient.txt", true);
                file.WriteLine(lines);
                file.Close();
            }
           ///}
        }
