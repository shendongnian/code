    private void RunParallel() {
        int numOfTasks = 8;
        progressBar1.Maximum = numOfTasks;
        progressBar1.Minimum = 0;
        try
        { 
            var context=TaskScheduler.FromCurrentSynchronizationContext()
            for (int i = 0; i < numOfTasks; i++)
            {
                Task.Factory.StartNew(()=>DoWork(i))
                        .ContinueWith(()=>UpdateBar(),context);
            }
        }
        catch (Exception exc)
        { 
          MessageBox.Show(exc.ToString(),"AAAAAARGH");
        }  
    }
    private void DoWork(object o1)
    {
        // do work...
     
    }
    private void UpdateBar()
    {
        if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
    }
