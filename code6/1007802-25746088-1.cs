    private async void button1_Click(object sender, EventArgs e)
    {
         var progress = new Progress<ProcessViewModel>(UpdateRow); //This makes a callback to UpdateRow when progress is reported.
    
         var tasks = Processes.Select(process => ProcessObject(process, report)).ToList();
         await Task.WhenAll(tasks);
    }
    
    private async Task ProcessObject(ProcessViewModel process, IProgress<ProcessViewModel> progress)
    {
        // my code is here with some loops
        await Task.Run(()=>
        {
            //Will be run in ThreadPool thread
            //Do whatever cpu bound work here
    
    
            //Still in the thread pool thread
            process.Progress++;
        
            // feedback to UI, calls UpdateRow on the UI thread.
            progress.Report(process); 
        });
    }
