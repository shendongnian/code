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
            Task task = new Task(action);
            task.Start(TaskScheduler.FromCurrentSynchronizationContext());
        }
