    Dictionary<Thread, Job> threads = new Dictionary<Thread, Job>();
    List<Job> foundedJobs = new List<Job>();
        public void StartAllJobs()
                {
                    try
                    {
                        if (CanExecuteJobs == false) return;
                        var jobs = GetAllTypesImplementingInterface(typeof(Job)); // get all job implementations of this assembly.
                        var enumerable = jobs as Type[] ?? jobs.ToArray();
                        if (jobs != null && enumerable.Any())  // execute each job
                        {
                            Job instanceJob = null;
                            var index = 0;
                            foreach (var job in enumerable)
                            {
                                if (IsRealClass(job)) // only instantiate the job its implementation is "real"
                                {
                                    try
                                    {
                                        instanceJob = (Job)Activator.CreateInstance(job);  // instantiate job by reflection
                                        foundedJobs.Add(instanceJob);
                                        var thread = new Thread(new ThreadStart(instanceJob.ExecuteJob))
                                        {
                                            IsBackground = true,
                                            Name = "SID" + index
                                        };   // create thread for this job execution method
                                        thread.Start();// start thread executing the job
                                        threads.Add(thread, job);
                                        index++;
                                    }
                                    catch (Exception ex)
                                    {
                                        App.Logger.Error(ex);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        App.Logger.Error(ex);
                    }
                }
