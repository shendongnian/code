    //create worker
    BackgroundWorker bw = new BackgroundWorker();
    //set progress to true
    bw.WorkerReportsProgress = true; 
    // handle events
    bw.DoWork += new DoWorkEventHandler(DoWork);
    bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
    //method for work
    private DoWork(object sender, DoWorkEventArgs e)
    {
    
    BackgroundWorker worker = sender as BackgroundWorker;
    List<Test> tests = ....
    for (Test t in tests)
    {
        switch(t.Name)
        {
            case "Test1":
                //Do something
                break;
            case "Test2":
                //Do something else 
                break;
            ...
            case "TestSpecial":
                // Here I want to:
                // 1. Tell UI to show an image on the screen
                // 2. Wait for the image to show up
                // 3. Continue with my test
                worker.ReportProgress(1);
                break;
            case "TestN+1":
                //Do something completly different
                break;
        }
    }
    } 
    //method for progress
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        //set your image here
    }
