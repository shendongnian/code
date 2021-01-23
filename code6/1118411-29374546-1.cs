    public void Start_Event(object sender, StartEventArgs e)
            {
                Task<bool> startTask = StartAsync();
    
                service.SetStartTask(startTask);
    
                DoOtherWork();
                DoOtherWork();
                DoOtherWork();
            }
    
    private Task<bool> StartAsync()
            {
                var taskCompletion = new TaskCompletionSource<bool>();
    
                service.startFinished += (p, e) => 
                {
                    taskCompletion.TrySetResult((e.Error == string.Empty) ? true : false); 
                };
    
                return taskCompletion.Task;
            }
    
    private void DoingWork()
            {
                for(int i = 0; i < 100; ++i)
                {
    
                }
                service.StartFinished(project, error);
            }
    
            private void DoOtherWork()
            {
                for (int i = 0; i < 100000; ++i)
                {                    
                }
            }
