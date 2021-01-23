    private async void button1_Click(object sender, EventArgs e)// <--Note the async modifier
    {
        // almost 15 process
        foreach (var process in Processes)
        {
            // call a async method to process
            await ProcessObject(process);
        }
    }
    
    private async Task ProcessObject(ProcessViewModel process)// <--Note the return type
    {
        // my code is here with some loops
        await Task.Run(()=>
        {
            //Will be run in ThreadPool thread
            //Do whatever cpu bound work here
        });
    
        //At this point code runs in UI thread
        process.Progress++;
    
        // feedback to UI
        UpdateRow(process);
    }
