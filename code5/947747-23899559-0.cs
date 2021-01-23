    class GoRunners {
    
        Semaphore runnersSemaphore;
    
        List<Result> results = new List<Result>();
    
        private void RunForestRun(object aRunner) {
            runnersSemaphore.Wait();
            try {
                Runner runner = (Runner)aRunner;
                results.Add(runner.Run());
            }
            finally { //A little safety in case a execption gets thrown inside "runner.Run()"
                runnersSemaphore.Release();
            }
        }
    
        const int MAX_RUNNERS = 2; //I hate magic numbers in code if they get spread across more than one line, move the max out to a const variable.
    
        private List<Result> Go() {
            List<Runners>() runners = CreateSomeRunners();
            runnersSemaphore = new Semaphore(MAX_RUNNERS, MAX_RUNNERS); // At most two threads at once
            runners.ForEach((runner) => new Thread(RunForestRun).Start(runner); )}
    
            for(int i = 0; i < MAX_RUNNERS; i++) {
                runnersSemaphore.WaitOne(); //Wait for the currently running runners to finish.
            }
    
            return results;
        }
    }
