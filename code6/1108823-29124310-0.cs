        public static Task Enqueue(Expression<Action> methodCall)
        {
            string jobId = BackgroundJob.Enqueue(methodCall);
            Task checkJobState = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    IMonitoringApi monitoringApi = JobStorage.Current.GetMonitoringApi();
                    JobDetailsDto jobDetails = monitoringApi.JobDetails(jobId);
                    string currentState = jobDetails.History[0].StateName;
                    if (currentState != "Enqueued" && currentState != "Processing")
                    {
                        break;
                    }
                    Thread.Sleep(100); // adjust to a coarse enough value for your scenario
                }
            });
            return checkJobState;
        }
