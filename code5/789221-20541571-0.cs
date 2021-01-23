        // The method that will be called when the schedule thread is started
        private void ProcessSchedule()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            // work out the length of time between now and the schedule time
            string today = DateTime.Now.ToString("dd.MM.yyy");
            DateTime abaseTime = Convert.ToDateTime(today);
            TimeSpan scheduleTime = schedules.First().Value.ActionTime;
            DateTime actionTime = abaseTime.Add(scheduleTime);
            // log the schedule is starting
            if (log.IsInfoEnabled) log.Info(String.Format("Schedule created. Next action will take place at {0}", actionTime.ToString()));
            while (Running)
            {
                // this kills this process
                if (threadStop.WaitOne(0))
                {
                    if (log.IsInfoEnabled) log.Info(String.Format("Schedules cancelled"));
                    break;
                }
                if (DateTime.Now < actionTime)
                {
                    //sleep 5 seconds before checking again. If we go any longer we keep our service from shutting down when it needs to.
                    threadStop.WaitOne(5000);
                    continue;
                }
             
                // tell the service control that it can action the schedules now
                ServiceControl.actionSchedule.Set();
               
                break;
            }
            
        }
