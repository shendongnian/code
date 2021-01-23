    //setting up your background worker.
    var worker = new BackgroundWorker();
    worker.DoWork += bgw_DoWork;
    worker.RunWorkerCompleted += bgw_WorkCompleted;
    worker.ProgressChanged += bgw_ProgressChanged;
    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {   
        e.Result = ProjectDbInteraction.QueryProject(currentProjDb);
    }
    private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //Here you can inspect the worker and update UI if needed.
    }
    
    private void bgw_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //check for errors, and other unexpected results first...
        //assuming that savedProj is some private member variable of your class, 
        //just assign the variable to the Result here.
        savedProj = (Project.Project)e.Result;
    }
