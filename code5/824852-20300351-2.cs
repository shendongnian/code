    void ExecuteInMainContext(Action action)
        {
            var synchronization = SynchronizationContext.Current;
            if (synchronization != null)
            {
                synchronization.Send(_ => action(), null);//sync
                //OR
                synchronization.Post(_ => action(), null);//async
            }
            else
                Task.Factory.StartNew(action);
            //OR
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            
            Task task = new Task(action);
            if (scheduler != null)
                task.Start(scheduler);
            else
                task.Start();
        }
