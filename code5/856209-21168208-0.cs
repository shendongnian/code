    private void RunParallel() {
        int numOfTasks = 8;
        progressBar1.Maximum = numOfTasks;
        progressBar1.Minimum = 0;
        try
        { 
            var context=TaskScheduler.FromCurrentSynchronizationContext()
            List<Task> allTasks = new List<Task>();
            for (int i = 0; i < numOfTasks; i++)
            {
                var task=Task.Factory.StartNew(()=>doWork(i))
                                     .ContinueWith(()=>UpdateBar(),context);
                allTasks.Add(task);
            }
        }
        catch (Exception exc)
        { 
          MessageBox.Show(exc.ToString(),"AAAAAARGH");
        }  
    }
    private void doWork(object o1)
    {
        // do work...
     
    }
    private void UpdateBar()
    {
        if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
    }
