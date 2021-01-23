    class GoRunners {
    
        Semaphore runnersSemaphore;
    
        List<Result> results = new List<Result>();
    
        private void RunForestRun(object aRunner) {
            try {
                Runner runner = (Runner)aRunner;
                var result = runner.Run(); 
                lock(results)
                {
                    results.Add(result)//List is not thread safe, you need to lock on it or use a different threadsafe collection (I don't know if there are any in .NET 3.5)
                }
            }
            finally { //A little safety in case a execption gets thrown inside "runner.Run()"
                runnersSemaphore.Release();
            }
        }
    
        const int MAX_RUNNERS = 2; //I hate magic numbers in code if they get spread across more than one line, move the max out to a const variable.
    
        private List<Result> Go() {
            List<Runners>() runners = CreateSomeRunners();
            runnersSemaphore = new Semaphore(MAX_RUNNERS, MAX_RUNNERS); // At most two threads at once
            foreach(var runner in runners)
            {
                runnersSemaphore.Wait(); //This goes in here now. New threads will not be started unless there is less than 2 runners running.
                new Thread(RunForestRun).Start(runner);
            }
    
            for(int i = 0; i < MAX_RUNNERS; i++) {
                runnersSemaphore.WaitOne(); //Wait for the currently running runners to finish.
            }
    
            return results;
        }
    }
