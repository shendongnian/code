    Task _task;
    CancellationTokenSource _terminator;
    
    protected override void OnStart()
    {
         _terminator = new CancellationTokenSource();
         _task = Task.Factory.StartNew(TaskBody, _terminator.Token);
    }
    
    private void TaskBody(object arg)
    {
         var ct = arg as CancellationToken;
    
         if (ct == null) throw new ArgumentException();
    
         while(!ct.sCancellationRequested)
         {
             YourOnTimerMethod();
             ct.WaitHandle.WaitOne(interval)
         }
    }
    
    public override void OnClose()
    {
        _terminator.Cancel();
        _task.Wait();
    }
